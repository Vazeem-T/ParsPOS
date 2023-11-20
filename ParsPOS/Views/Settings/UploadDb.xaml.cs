using CommunityToolkit.Maui.Storage;
using ParsPOS.Services;
using SQLite;
using System.Text;

namespace ParsPOS.Views.Settings;

public partial class UploadDb : ContentPage
{
    private SQLiteAsyncConnection _db;
    private string selectedDatabaseFilePath;
    private readonly IFileSaver _fileSaver;
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    public UploadDb()
	{
		InitializeComponent();
        _db = new SQLiteAsyncConnection(GetExistingDatabaseFilePath());
        _fileSaver = DependencyService.Get<IFileSaver>();
    }
  

    private string GetExistingDatabaseFilePath()
    {
        // Return the path to the existing database file
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3");
    }

    private async void OnSelectNewDatabaseFileClicked(object sender, EventArgs e)
    {
        try
        {
            var fileResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                    {
                        { DevicePlatform.Android, new[] { "*/*" } },
                        { DevicePlatform.iOS, new[] { "*/*" } }
                        // Add more platform-specific file types if required
                    }),
                PickerTitle = "Select a new database file"
            });

            if (fileResult != null)
            {
                selectedDatabaseFilePath = fileResult.FullPath;
                // Display the selected file path to the user or perform other actions
            }
        }
        catch (Exception ex)
        {
            // Handle file picker errors
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(selectedDatabaseFilePath))
            {
                // Handle the case where a file has not been selected
                await DisplayAlert("Error", "Please select a new database file first.", "OK");
                return;
            }

            // Close the existing database connection if it's open
            if (_db != null)
            {
                await _db.CloseAsync();
                _db = null;
            }

            // Replace the database file with the selected new database file
            string newDbFilePath = selectedDatabaseFilePath; // Use the selected file path
            string existingDbFilePath = GetExistingDatabaseFilePath(); // Path to the existing database file

            if (File.Exists(newDbFilePath))
            {
                File.Copy(newDbFilePath, existingDbFilePath, true);
            }

            // Reopen the database connection
            _db = new SQLiteAsyncConnection(existingDbFilePath);

            // Perform any necessary database operations

            // Display a success message to the user
            await DisplayAlert("Success", "Database has been updated.", "OK");
        }
        catch (Exception ex)
        {
            // Handle errors and display an error message to the user
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
        }
    }

    private async void BackUpButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Get the Downloads folder path.
            var databaseFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3");

            // Get the Downloads folder path.
            var storage = FileSystem.AppDataDirectory;
            string downloadsFolderPath = Path.Combine(storage,"Downloads");
            var status = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (status != PermissionStatus.Granted)
            {
                return;
            }
            // Create a directory for backups if it doesn't exist
            Directory.CreateDirectory(downloadsFolderPath);

            // Create a new backup file path.
            string backupFilePath = Path.Combine(downloadsFolderPath, $"PARSPOS_BackUP{DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")}.db3");

            // Copy the database file to the backup file path.
            
            File.Copy(databaseFilePath, backupFilePath, true); // Note the corrected parameters

            // Check if the backup file exists
            if (!File.Exists(backupFilePath))
            {
                // Handle the case where the backup file does not exist
                await DisplayAlert("Error", "Backup file not found.", "OK");
                return;
            }

            // Create a file share request for the backup file
            var shareRequest = new ShareFileRequest
            {
                Title = "Share Backup File",
                File = new ShareFile(backupFilePath),
            };

            // Share the file
            await Share.RequestAsync(shareRequest);

            // Display a success message to the user
            await DisplayAlert("Backup Success", "Database backup created successfully.", "OK");


        }
        catch (Exception ex)
        {
            // Handle exceptions, e.g., display an error message
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }

    }
}
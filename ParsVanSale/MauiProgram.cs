using CommunityToolkit.Maui;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ParsVanSale.Services;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;
using SQLite;
using System.Data;
using The49.Maui.BottomSheet;
using The49.Maui.Insets;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace ParsVanSale
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseBottomSheet()
				.UseMauiCommunityToolkit()
				.UseSimpleShell()
				.UseSimpleToolkit()
				.UseBarcodeReader()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
					fonts.AddFont("fa-brands-400.otf", "FAB");
					fonts.AddFont("Fa-Regular-400.otf", "FAR");
					fonts.AddFont("Fa-solid-900.otf", "FAS");
				});

			ConfigurationService.ConfigureService(builder.Services);
			builder.Services.AddScoped<IDbConnection>((sp) =>
			{
				var config = sp.GetRequiredService<IConfiguration>();
				var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSSALE.db3");
				var connectionstring = $"Data Source={filePath};";
				return new SqliteConnection(connectionstring);
			});
			#region
			builder.ConfigureMauiHandlers(h =>
			{
				h.AddHandler(typeof
					(CameraBarcodeReaderView),typeof(CameraBarcodeReaderViewHandler));
				h.AddHandler(typeof
					(CameraView), typeof(CameraViewHandler));
				h.AddHandler(typeof
					(BarcodeGeneratorView), typeof(BarcodeGeneratorViewHandler));
			});
			#endregion

#if DEBUG
			builder.Logging.AddDebug();
#endif
			return builder.Build();
		}
	}
}

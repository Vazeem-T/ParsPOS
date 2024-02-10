using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsVanSale.Services;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace ParsVanSale.ViewModel.DownloadViewModel
{
	public partial class ProductDownloadModel : BaseViewModel
	{
		private CommonHttpServices commonHttpServices;
		private readonly HttpClient client;
		private DownloadViewmodel _downloadViewmodel;
		private int apicurrentPage = 1;
		int downloadId = 0;
		SqlConnection con;
		public ProductDownloadModel()
		{
			commonHttpServices = new CommonHttpServices();
			client = commonHttpServices.GetHttpClient();
			_downloadViewmodel = new DownloadViewmodel();
		}
		private async Task<int> GetTotalItemCountAsync(string apiUrl)
		{
			try
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<int>(content);
				}
				else
				{
					// Handle the case where the API request was not successful
					throw new Exception("Failed to retrieve total item count.");
				}
			}
			catch (Exception ex)
			{
				return 0;
			}
		}


		[RelayCommand]
		private async Task<int> DownloadDataAsync()
		{
			//IsDownloading = true;
			int Progress = 0;
			int loadProgress = 0;
			bool isSuccess = true;
			try
			{
				//Expression<Func<SettingsTb, int>> Orderby = item => item.Id;
				//var check = await App.Database.GetFirstAsync(null, Orderby);
				//if(check != null)
				//{
				//	if(check.IsApiEnable == true)
				//	{
				var baseurl = commonHttpServices.GetBaseUrl();
				string countApiUrl = $"{baseurl}/ImportDb/GetInvItemCount"; //Change
				string dataApiUrl = $"{baseurl}/ImportDb/InvItm?page="; //Change
				int Count = await GetTotalItemCountAsync(countApiUrl);
				Expression<Func<Invitm, int>> orderBy = item => item.Id;
				var invitem = await App.Database.GetFirstAsync(null, orderBy);
				if (invitem != null)
				{
					await App.Database.DeleteAll<Invitm>();//Change
				}
				await App.Database.InsertAsync(new DownloadDt //Change
				{
					Description = "Downloading",
					DownloadDescription = "Item Master",
					DownloadTime = DateTime.Now,
					IsRunning = true,
					TotalCount = Count,
					Progress = 0
				});
				DownloadDt downloadDt = await App.Database.GetDownloadItm("Item Master"); //Change
				downloadId = downloadDt.DownloadId;
				int index = _downloadViewmodel.DownloadItem.IndexOf(_downloadViewmodel.DownloadItem.FirstOrDefault(item => item.DownloadId == downloadId));
				while (loadProgress < Count)
				{
					string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

					HttpResponseMessage response = await client.GetAsync(pageDataUrl);

					if (response.IsSuccessStatusCode)
					{
						string content = await response.Content.ReadAsStringAsync();
						var pageData = JsonConvert.DeserializeObject<List<Invitm>>(content);//Change

						foreach (var item in pageData)
						{
							await App.Database.InsertAsync(item);
							loadProgress = loadProgress + 1;
							await App.Database.UpdateDownloadProgress(downloadId, loadProgress);
							if (index != -1)
							{
								downloadDt.Progress = loadProgress;
								_downloadViewmodel.DownloadItem[index] = downloadDt;
								OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
							}

						}
						apicurrentPage++;
					}
					else
					{
						isSuccess = false;
						await App.Database.UpdateDownloadComplete(downloadId, isSuccess);
						if (index != -1)
						{
							downloadDt.IsSuccess = isSuccess;
							_downloadViewmodel.DownloadItem[index] = downloadDt;
							OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
						}
						await Shell.Current.DisplayAlert("Alert", "Failed to download Product Check the Api Connection or Contact the Admin", "OK");


					}
				}
				if (isSuccess)
				{
					await App.Database.UpdateDownloadComplete(downloadId, isSuccess);
					if (index != -1)
					{
						downloadDt.IsSuccess = isSuccess;
						_downloadViewmodel.DownloadItem[index] = downloadDt;
						OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
					}
					//}
					//}
					//else
					//{
					//	int Count = await GetInvItemCount();
					//	Expression<Func<Invitm, int>> orderBy = item => item.Id;
					//	var invitem = await App.Database.GetFirstAsync(null, orderBy);
					//	if (invitem != null)
					//	{
					//		await App.Database.DeleteAll<Invitm>();//Change
					//	}
					//	while (loadProgress < Count)
					//	{
					//		await GetInvItm(apicurrentPage, 100);
					//		loadProgress += 100;
					//		apicurrentPage++;
					//	}
					//}
				}
			}
			catch (Exception ex)
			{
				await App.Database.UpdateDownloadComplete(downloadId, false);
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
			finally
			{
				client.Dispose();
				//IsDownloading = true;
			}
			return Progress;
		}

		async Task GetInvItm(int pageNumber, int pageSize)
		{
			int startRow = (pageNumber - 1) * pageSize + 1;
			int endRow = startRow + pageSize - 1;
			try
			{
				await ServerDbConnection.Instance.InitializeAsync();
				using (con = ServerDbConnection.Instance.GetConnection())
				{
					string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ItemId) AS RowNum FROM InvItm) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						using (SqlDataReader read = cmd.ExecuteReader())
						{
							while (read.Read())
							{
								try
								{
									Invitm itm = MapDataReaderToObject<Invitm>(read);
									itm.ItemCode = read["Item Code"].ToString();
									await App.Database.InsertAsync(itm);
								}
								catch (Exception ex)
								{
									Console.WriteLine($"Error processing row: {ex.Message}");
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		async Task<int> GetInvItemCount()
		{
			try
			{
				await ServerDbConnection.Instance.InitializeAsync();
				using (con = ServerDbConnection.Instance.GetConnection())
				{
					string query = $"SELECT Count(*) from InvItm";
					using (SqlCommand cmd = new SqlCommand(query, con))
					{
						int count = Convert.ToInt32(cmd.ExecuteScalar());
						return count;
					}
				}

			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		private T MapDataReaderToObject<T>(SqlDataReader reader) where T : new()
		{
			T obj = new T();

			try
			{
				for (int i = 0; i < reader.FieldCount; i++)
				{
					string columnName = reader.GetName(i);
					object value = reader.GetValue(i);

					PropertyInfo property = typeof(T).GetProperty(GetPropertyName<T>(columnName));

					if (property != null)
					{
						// Handle conversion between double and float if necessary
						if (property.PropertyType == typeof(float) && value is double doubleValue)
						{
							value = (float)doubleValue;
						}

						// Convert DBNull to null for nullable types
						value = value == DBNull.Value ? null : value;

						property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error mapping data: {ex.Message}");
			}

			return obj;
		}

		// Helper method to get the property name based on the column name using attributes
		private string GetPropertyName<T>(string columnName)
		{
			try
			{
				var property = typeof(T).GetProperties()
				.FirstOrDefault(p => Attribute.IsDefined(p, typeof(ColumnAttribute)) &&
									 ((ColumnAttribute)Attribute.GetCustomAttribute(p, typeof(ColumnAttribute))).Name == columnName);

				return property?.Name ?? columnName;
			}
			catch (Exception ex)
			{
				return string.Empty;
			}
		}

		[AttributeUsage(AttributeTargets.Property)]
		public class ColumnAttribute : Attribute
		{
			public string Name { get; }

			public ColumnAttribute(string name)
			{
				Name = name;
			}
		}


		[RelayCommand]
		private async Task BackgroundCheck(string date)
		{
			try
			{
				var baseurl = commonHttpServices.GetBaseUrl();
				string dataApiUrl = $"{baseurl}/DirectDb/GetModiInvItm?date="; //Change
				string pageDataUrl = $"{dataApiUrl}{date}";
				HttpResponseMessage response = await client.GetAsync(pageDataUrl);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					var pageData = JsonConvert.DeserializeObject<List<Invitm>>(content);//Change

					foreach (var item in pageData)
					{
						Expression<Func<Invitm, bool>> predicate = item => item.ItemId == item.ItemId;
						var chk = await App.Database.GetFirstAsync<Invitm, bool>(predicate, null);
						if (chk != null)
						{
							await App.Database.UpdateAsync(item);
						}
						else
						{
							await App.Database.InsertAsync(item);
						}
					}
				}
			}
			catch(Exception ex)
			{
			}
		}
	}
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ParsVanSale.Services;
using System.Data;
using Dapper;

namespace ParsVanSale.ViewModel
{
	public partial class NetworkViewModel : BaseViewModel
	{
		public ObservableCollection<NetworkIP> Items { get; set; } = new();
		private HttpClient client;
		[ObservableProperty]
		string selectedProtocol = "Https";

		[ObservableProperty]
		bool deletebuttonVisible = false;

		[ObservableProperty]
		NetworkIP networkIP;

		[ObservableProperty]
		string buttonText = "Submit";
		private IDbConnection _connection;
		public NetworkViewModel(IDbConnection connection)
		{
			LoadOnOpenCommand.ExecuteAsync(null);
			_connection = connection;
			NetworkIP = new();
		}
		[RelayCommand]
		async Task LoadOnOpenAsync()
		{
			Expression<Func<NetworkIP, bool>> orderBy = item => item.IsConnected;
			var pageData = await App.Database.GetFilteredAsync(null, orderBy);
			foreach (var item in pageData)
			{
				Items.Add(item);
			}
		}
		[RelayCommand]
		async Task OnSubmitAsync()
		{
			try
			{
				if(Items.Count != 0 )
				_connection.Query<NetworkIP>("Update NetworkIP Set IsConnected = false");
				if (NetworkIP.Id != 0)
				{
					NetworkIP.IsConnected = true;
					await App.Database.UpdateAsync(NetworkIP);
				}
				else
				{
					NetworkIP = new()
					{
						IPAddress = NetworkIP.IPAddress,
						CreatedTime = DateTime.Now,
						LastDbUsed = DateTime.Now,
						IsConnected = true,
						Protocol = SelectedProtocol,
					};
					await App.Database.InsertAsync(NetworkIP);
					
				}
				Items.Clear();
				Expression<Func<NetworkIP, bool>> orderBy = item => item.IsConnected;
				var pageData = await App.Database.GetFilteredAsync(null, orderBy);
				foreach (var item in pageData)
				{
					Items.Add(item);
				}
				OnPropertyChanged(nameof(Items));
				ButtonText = "Submit";
				var current = Connectivity.NetworkAccess;
				if (current == NetworkAccess.Internet)
				{
//#if DEBUG
				HttpClientHandlerService handler = new HttpClientHandlerService();
				client = new HttpClient(handler.GetPlatformMessageHandler());
//#else
//        client = new HttpClient();
//#endif
					client.Timeout = TimeSpan.FromSeconds(3);
					var api = $"{SelectedProtocol}://{NetworkIP.IPAddress}/API/DirectDb/Healthchk";
					client.BaseAddress = new Uri(api);
					HttpResponseMessage response = await client.GetAsync("");
					if (response.IsSuccessStatusCode)
					{
						NetworkIP = new();
						DeletebuttonVisible = false;
						await Shell.Current.DisplayAlert("Success!", "Connection Successful", "OK");
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert",ex.Message, "OK");
			}
			
		}
		[RelayCommand]
		async Task SelectionChanged()
		{
			if (NetworkIP.Id != 0)
			{
				ButtonText = "Update";
				SelectedProtocol = NetworkIP.Protocol ?? SelectedProtocol;
				DeletebuttonVisible = true;
			}
		}
		[RelayCommand]
		async Task<bool> ISApiConnectedAsync()
		{
			try
			{
				var current = Connectivity.NetworkAccess;

				if (current == NetworkAccess.Internet)
				{
//#if DEBUG
					HttpClientHandlerService handler = new HttpClientHandlerService();
					client = new HttpClient(handler.GetPlatformMessageHandler());
//#else
//        client = new HttpClient();
//#endif
					client.Timeout = TimeSpan.FromSeconds(10);
					var api = $"{SelectedProtocol}://{NetworkIP.IPAddress}/API/DirectDb/Healthchk";
					client.BaseAddress = new Uri(api);
					HttpResponseMessage response = await client.GetAsync("");
					if (response.IsSuccessStatusCode)
					{
						await Shell.Current.DisplayAlert("Success!", "Connection Successful", "OK");
					}
				}

				return false;
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
				return false;

			}
		}

		
		[RelayCommand]
		async Task DeleteAsync()
		{
			if (NetworkIP != null)
			{
				var result = await Shell.Current.DisplayAlert("Alert", $"Do you want to Delete this Network with IP / URL : {NetworkIP.IPAddress}", "Yes", "No");
				if(result)
				{
					_connection.Query<NetworkIP>($"Delete from NetworkIP Where Id = {NetworkIP.Id}");
					Items.Remove(NetworkIP);
					OnPropertyChanged(nameof(Items));
					NetworkIP = new();
					DeletebuttonVisible = false;
				}
			}
		}
	}
}

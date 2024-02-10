using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class SqlServerViewModel : BaseViewModel
	{
		public ObservableCollection<SqlServerIPSettings> Items { get; set; } = new();
		[ObservableProperty]
		bool deletebuttonVisible = false;

		[ObservableProperty]
		SqlServerIPSettings _IPSettings;

		[ObservableProperty]
		string buttonText = "Submit";

		private IDbConnection _connection;
		public SqlServerViewModel(IDbConnection coneection)
		{
			LoadOnOpenCommand.ExecuteAsync(null);
			_connection = coneection;
			IPSettings = new();
		}
		[RelayCommand]
		async Task LoadOnOpenAsync()
		{
			Expression<Func<SqlServerIPSettings, bool>> orderBy = item => item.IsConnected;
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
				if (Items.Count != 0)
					_connection.Query<SqlServerIPSettings>("Update SqlServerIPSettings Set IsConnected = false");
				if (IPSettings.Id != 0)
				{
					IPSettings.IsConnected = true;
					await App.Database.UpdateAsync(IPSettings);
				}
				else
				{
					IPSettings.IsConnected = true;
					IPSettings.CreatdTm = DateTime.Now;
					await App.Database.InsertAsync(IPSettings);

				}
				Items.Clear();
				Expression<Func<SqlServerIPSettings, bool>> orderBy = item => item.IsConnected;
				var pageData = await App.Database.GetFilteredAsync(null, orderBy);
				foreach (var item in pageData)
				{
					Items.Add(item);
				}
				OnPropertyChanged(nameof(Items));
				ButtonText = "Submit";
				//Connection Check

				using (SqlConnection con = new($"Data Source={IPSettings.IP};Initial Catalog={IPSettings.Database};Persist Security Info=True;User ID={IPSettings.User};Password={IPSettings.Password};Encrypt=false;TrustServerCertificate=true"))
				{
					con.Open();

					if (con.State == System.Data.ConnectionState.Open)
					{
						await Shell.Current.DisplayAlert("Success", "Your Connection is Successful", "OK");
					}
					else
					{
						await Shell.Current.DisplayAlert("Alert", "Check Your Connection!", "OK");
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}

		}

		[RelayCommand]
		async Task SelectionChanged()
		{
			if (IPSettings.Id != 0)
			{
				ButtonText = "Update";
				DeletebuttonVisible = true;
			}
		}
		[RelayCommand]
		async Task TestConnection()
		{
			try
			{
				using (SqlConnection con = new($"Data Source={IPSettings.IP};Initial Catalog={IPSettings.Database};Persist Security Info=True;User ID={IPSettings.User};Password={IPSettings.Password};Encrypt=false;TrustServerCertificate=true"))
				{
					con.Open();

					if (con.State == System.Data.ConnectionState.Open)
					{
						await Shell.Current.DisplayAlert("Success", "Your Connection is Successful", "OK");
					}
					else
					{
						await Shell.Current.DisplayAlert("Alert", "Check Your Connection!", "OK");
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert",ex.Message, "OK");
			}
		}

		[RelayCommand]
		async Task DeleteAsync()
		{
			if (IPSettings != null)
			{
				var result = await Shell.Current.DisplayAlert("Alert", $"Do you want to Delete this Network with IP / URL : {IPSettings.IP}", "Yes", "No");
				if (result)
				{
					_connection.Query<SqlServerIPSettings>($"Delete from NetworkIP Where Id = {IPSettings.Id}");
					Items.Remove(IPSettings);
					OnPropertyChanged(nameof(Items));
					IPSettings = new();
					DeletebuttonVisible = false;
				}
			}
		}
	}
}

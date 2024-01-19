using CommunityToolkit.Mvvm.ComponentModel;
using Dapper;
using ParsPOS.Services;
using ParsPOS.ViewModel;
using System.Collections.ObjectModel;
using System.Data;

namespace ParsPOS.Views.BottomSheet;

public partial class DynamicPOP 
{
	public ObservableCollection<dynamic> ItmList { get; set; } = new();

	int selectedItem;

	string searchtxt;

	PopupButtonsSelection popselect;
	public ObservableCollection<string> columnHeaders { get; set; } = new();
	BaseViewModel Model;
	private readonly PopupButtonsSelectionWrapper _popSelectWrapper;
	string SelectedOpt;
	int page; int pageSize = 15;
	private readonly IDbConnection _connection;
	public DynamicPOP()
	{
		InitializeComponent();
	}
	public DynamicPOP(ObservableCollection<dynamic> itmList, int selectedItem, string searchtxt, PopupButtonsSelection popselect, ObservableCollection<string> columnHeaders, BaseViewModel model, PopupButtonsSelectionWrapper popSelectWrapper, string selectedOpt, int page, int pageSize, IDbConnection connection)
	{
		ItmList = itmList;
		Model = model;
		_popSelectWrapper = popSelectWrapper;
		SelectedOpt = selectedOpt;
		_connection = connection;
	}

	async Task DynamicPopSelect(string selected)
	{
		try
		{
			if (Enum.TryParse(selected, true, out PopupButtonsSelection selection))
			{
				int skipCount = (page - 1) * pageSize;
				var query = "";
				switch (selection)
				{
					case PopupButtonsSelection.ProductCode:
						query = $"SELECT ItemCode, Description, Unit, ActiveCost, UnitPrice, BarCode FROM InvItm ORDER BY ItemCode LIMIT {pageSize} OFFSET {skipCount}";
						break;
					case PopupButtonsSelection.AccMast:
						query = $"Select AccDescr,Alias,ClosingBal,OpnBal from AccMast ORDER BY AccountNo LIMIT {pageSize} OFFSET {skipCount}";
						break;
					default:
						break;
				}
				var pageData = _connection.Query<dynamic>(query);
				pageData.ToList();
				foreach (var item in pageData.ToList())
				{
					ItmList.Add(item);
				}
				if (ItmList != null && ItmList.Count > 0)
				{
					var firstItem = ItmList.FirstOrDefault();

					var itemType = firstItem.GetType();

					if (itemType != null)
					{
						var properties = itemType.GetProperties();

						foreach (var property in properties)
						{
							// Check if the property value is null before adding to columnHeaders
							var propertyValue = property.GetValue(firstItem);
							if (propertyValue != null)
							{
								columnHeaders.Add(property.Name);
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
		}
	}

}
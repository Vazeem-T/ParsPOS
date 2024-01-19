using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class CustomCalculations
    {
		public static string Packing(int ItemId)
        {
            string BUnit;
            var ItemDt = App.Database.GetItemOnItemId(ItemId).Result;
            if(ItemDt != null)
            {
                if(ItemDt.ItemId == ItemDt.BaseId)
                {
                    return "Base Item"; 
                }
                else
                {
                    BUnit = App.Database.GetUnitOnBaseItm(ItemDt.BaseId).Result;
                    string Output = $"{ItemDt.VDown} {ItemDt.Unit} = {ItemDt.VUP} {BUnit}";
                    return Output ;
                }
            }
            return "";
        }
        public static string DisplayQty(ObservableCollection<RFOCInvitm> Items)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in Items)
            {
				if (item.Qty != null && item.Qty != 0)
				{
					string qtyUnitString = $"{item.Qty} {item.Unit}";
					result.Append(qtyUnitString);

					if (Items.Count(item => item.Qty > 0) > 1 && item != Items.Last())
					{
						result.Append(", ");
					}
				}
			}
            return result.ToString();
        }
        public static double TotalFOCQty(PurchaseDetTb purchaseDetTb, ObservableCollection<RFOCInvitm> rFOCInvitm)
        {
			double Total = 0;
			foreach (var item in rFOCInvitm)
            {
				if (item.Qty != null && item.Qty != 0)
				{
					float? qty = item.Qty;
					double? SelctInvPmult = purchaseDetTb.PMult;
					float? SelectFOCPmult = (float)(App.Database.GetPMult(item.ProdCode).Result);
					Total = (Total + qty * (SelectFOCPmult / SelctInvPmult))?? 0;
   				}
			}
			return Total;
		}
    }
}

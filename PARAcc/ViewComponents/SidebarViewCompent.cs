using Dapper;
using Microsoft.AspNetCore.Mvc;
using PARSAcc.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PARSAcc.ViewComponents
{
    [ViewComponent(Name = "_sidebar")]
    public class SidebarViewCompent : ViewComponent
    {
        private readonly IDbConnection _connection;

        public SidebarViewCompent(IDbConnection connection)
        {
            _connection = connection;
        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var menuItems = _connection.Query<MenuTb>("Select * from MenuTb where ParentNo = 0").ToList();

			foreach (var menuItem in menuItems)
			{
				FetchSubmenus(menuItem);
				if (!string.IsNullOrEmpty(menuItem.langEnglish))
				{
					// Use a regular expression to remove characters that visually look like an ampersand
					menuItem.langEnglish = Regex.Replace(menuItem.langEnglish, @"[&＆]", string.Empty).Trim();
				}
			}

			return View("/Views/Shared/_sidebar.cshtml", menuItems);
		}

		private void FetchSubmenus(MenuTb menuItem)
		{
			menuItem.SubItems = _connection.Query<MenuTb>($"Select * from MenuTb where ParentNo = {menuItem.MenuItemNo} And IsBar = 0 order by OrdNo").ToList();

			foreach (var subItem in menuItem.SubItems)
			{
				if (subItem.IsParent == true)
				{
					FetchSubmenus(subItem);
				}

				if (!string.IsNullOrEmpty(subItem.langEnglish))
				{
					// Use a regular expression to remove characters that visually look like an ampersand
					subItem.langEnglish = Regex.Replace(subItem.langEnglish, @"[&＆]", string.Empty).Trim();
				}
			}
		}
	}
}

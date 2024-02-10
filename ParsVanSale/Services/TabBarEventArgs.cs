﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
	public class TabBarEventArgs : EventArgs
	{
		public PageType CurrentPage { get; private set; }

		public TabBarEventArgs(PageType currentPage)
		{
			CurrentPage = currentPage;
		}
	}
}

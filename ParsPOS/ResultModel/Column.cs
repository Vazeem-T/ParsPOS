using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ResultModel
{
	public class Column
	{
		public string Header { get; set; }
		public string PropertyName { get; set; } 
		public string StringFormat { get; set; } 
		public Func<object, object> ValueConverter { get; set; }
	}
}

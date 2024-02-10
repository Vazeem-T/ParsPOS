using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
	public class SqlServerIPSettings
	{
		[PrimaryKey ,AutoIncrement]
		public int  Id { get; set; }
		public string IP {  get; set; }
		public string Database {  get; set; }
		public string User {  get; set; }
		public string Password { get; set; }
		public bool IsConnected { get; set; }
		public DateTime CreatdTm { get; set; }

		[Ignore]
		public int Slno { get; set; }
	}
}

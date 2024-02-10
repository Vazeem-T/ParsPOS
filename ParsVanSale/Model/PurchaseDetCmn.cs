using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Model
{
	public class PurchaseDetCmn
	{
		[PrimaryKey , AutoIncrement]
		public int Id { get; set; }
		public int SlNo { get; set; }
		public DateTime InvDate {  get; set; }
		public string Description { get; set; }
		public string Reference { get; set; }
		public int SuppAcNo { get; set; }
		public string SuppAlias { get; set; }
		public string SuppDesc { get; set; }
		public DateTime CreatdTm { get; set; }
		public float TotalQty { get; set; }
		public float Tax {  get; set; }
		public float Net {  get; set; }
		public string CreadtdBy { get; set; }
		public bool isCompleted {  get; set; }
		public bool isModified {  get; set; }
		public DateTime ModiTm { get; set; }
	}
}

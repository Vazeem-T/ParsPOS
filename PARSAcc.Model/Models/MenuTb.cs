using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARSAcc.Model.Models
{
    public class MenuTb
    {
        public int MenuItemNo { get; set; }
        public int ParentNo { get; set; }
        public bool IsBar { get; set; }
        [MaxLength(15)]
        public string? ModuleCode { get; set; }
        [MaxLength(80)]
        public string? langEnglish {  get; set; }
        [MaxLength(80)]
        public string? langArabic { get; set; }
        public short ? OrdNo { get; set; }
        public bool DefRights { get; set; }
        public bool DefVisible { get; set; }
        public bool OnlyProgrammer { get; set; }
        public bool IsParent { get; set; }
        [MaxLength(20)]
        public string? IconKey { get; set; }
        public bool Ischeck { get; set; }
        public string? Krystr { get; set; }
        public bool Hide {  get; set; }
        public List<MenuTb> SubItems { get; set; } = new List<MenuTb>();
        public bool HasSubItems => SubItems.Any();
    }
}

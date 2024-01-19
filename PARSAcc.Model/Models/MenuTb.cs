using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PARSAcc.Model.Models;

public partial class MenuTb
{
    public int MenuItemNo { get; set; }

    public int? ParentNo { get; set; }

    public bool IsBar { get; set; }

    public string? ModuleCode { get; set; }

    public string? LangEnglish { get; set; }

    public string? LangArabic { get; set; }

    public short? OrdNo { get; set; }

    public bool DefRights { get; set; }

    public bool DefVisible { get; set; }

    public bool OnlyPrgmr { get; set; }

    public bool IsParent { get; set; }

    public string? IconKey { get; set; }

    public bool IsCheck { get; set; }

    public string? KeyStr { get; set; }

    public bool Hide { get; set; }

    [NotMapped]
    public List<MenuTb> SubItems { get; set; } = new List<MenuTb>();
    [NotMapped]
    public bool HasSubItems => SubItems.Any();
}

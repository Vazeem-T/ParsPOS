using System;
using System.Collections.Generic;

namespace PARSAcc.Model.Models;

public partial class BarObject
{
    public int? FmtNo { get; set; }

    public byte? ObjId { get; set; }

    public short? OrdNo { get; set; }

    public bool FontBold { get; set; }

    public bool FontItalic { get; set; }

    public string? FontName { get; set; }

    public short? FontSize { get; set; }

    public bool Strikethrough { get; set; }

    public bool UnderLine { get; set; }

    public double? Left { get; set; }

    public double? Top { get; set; }

    public double? Width { get; set; }

    public double? Height { get; set; }

    public string? Caption { get; set; }

    public bool HasText { get; set; }

    public bool Scaling { get; set; }

    public string? CurrCode { get; set; }

    public byte? Fmt { get; set; }

    public byte? EndTxt { get; set; }

    public bool Ean13 { get; set; }

    public bool IsVertical { get; set; }

    public byte? Alignment { get; set; }

    public bool AlgnAtGiven { get; set; }

    public bool IsBarCode { get; set; }

    public byte IsElseBtype { get; set; }

    public bool IsUniCode { get; set; }

    public bool CanGrow { get; set; }

    public byte SubNo { get; set; }

    public byte[]? Img { get; set; }

    public long ForeColor { get; set; }
}

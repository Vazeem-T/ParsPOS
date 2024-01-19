using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PARSAcc.Model.Models;

public partial class InvItm
{
    public string? ItemCode { get; set; }

    public string? BarCode { get; set; }

    public string? Unit { get; set; }

    public string? Description { get; set; }

    public string? Posdescription { get; set; }

    public string? Model { get; set; }

    public double UnitPrice { get; set; }

    public double UnitPriceWs { get; set; }

    public string? Size { get; set; }

    public string? Weight { get; set; }

    public int Vup { get; set; }

    public int Vdown { get; set; }

    public float Pmult { get; set; }

    public bool SdiscOn { get; set; }

    public double DiscountVal { get; set; }

    public float Dim1 { get; set; }

    public float Dim2 { get; set; }

    public float Dim3 { get; set; }

    public string? Dim1Caption { get; set; }

    public string? Dim2Caption { get; set; }

    public string? Dim3Caption { get; set; }

    public bool EnaDimPara { get; set; }

    public bool ItemWithSrlNo { get; set; }

    public bool IsWeighing { get; set; }

    public bool IsPcs { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime CreatedDt { get; set; }

    public bool IsComment { get; set; }

    public double OfferPrice { get; set; }

    public DateTime ModiDt { get; set; }

    public double ActiveCost { get; set; }

    public bool Blocked { get; set; }

    public bool? DelId { get; set; }

    public string? OfferDescr { get; set; }

    public short? Tmp { get; set; }

    public bool EnaRestrct { get; set; }

    public string? ItmBrId { get; set; }

    public byte WgCodeLength { get; set; }

    public double? SpMult { get; set; }

    public bool AqtyPrint { get; set; }

    public string? ArbDescription { get; set; }

    public bool AskWgt { get; set; }

    public float DisplayCost { get; set; }

    public short ExpDays { get; set; }

    public int ItemId { get; set; }

    public int BaseId { get; set; }

    public bool IsOrder { get; set; }

    public bool EnaLnDisc { get; set; }

    public bool DoTrWithTax { get; set; }

    public double PriceWithTax { get; set; }

    public double Mrp { get; set; }

    public bool IsTmm { get; set; }
}

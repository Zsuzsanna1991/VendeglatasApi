using System;
using System.Collections.Generic;

namespace VendeglatasApi.Models;

public partial class Furdok
{
    public int Id { get; set; }

    public string? Nev { get; set; }

    public string? Cim { get; set; }

    public string? Iranyitoszam { get; set; }

    public DateTime? Regtime { get; set; }

    public int? Varosid { get; set; }

    public virtual Varosok? Varos { get; set; }
}

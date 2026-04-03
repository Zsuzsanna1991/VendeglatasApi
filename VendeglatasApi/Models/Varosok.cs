using System;
using System.Collections.Generic;

namespace VendeglatasApi.Models;

public partial class Varosok
{
    public int Id { get; set; }

    public string? Nev { get; set; }

    public string? Tipus { get; set; }

    public int? Lakosokszama { get; set; }

    public DateTime? Regtime { get; set; }

    public virtual ICollection<Furdok> Furdoks { get; set; } = new List<Furdok>();
}

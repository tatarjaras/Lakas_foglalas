using System;
using System.Collections.Generic;

namespace LakasfoglalasBackEnd.Models;

public partial class Varosok
{
    public int Id { get; set; }

    public string Varos { get; set; } = null!;

    public int MegyeId { get; set; }

    public virtual ICollection<Lakasok> Lakasoks { get; set; } = new List<Lakasok>();

    public virtual Megyek Megye { get; set; } = null!;
}

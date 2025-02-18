using System;
using System.Collections.Generic;

namespace LakasfoglalasBackEnd.Models;

public partial class Megyek
{
    public int Id { get; set; }

    public string Megye { get; set; } = null!;

    public virtual ICollection<Varosok> Varosoks { get; set; } = new List<Varosok>();
}

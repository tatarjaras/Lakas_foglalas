using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LakasfoglalasBackEnd.Models;

public partial class Megyek
{
    public int Id { get; set; }

    public string Megye { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Varosok> Varosoks { get; set; } = new List<Varosok>();
}

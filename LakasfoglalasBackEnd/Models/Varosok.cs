using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LakasfoglalasBackEnd.Models;

public partial class Varosok
{
    public int Id { get; set; }

    public string Varos { get; set; } = null!;

    public int MegyeId { get; set; }

    [JsonIgnore]
    public virtual ICollection<Lakasok> Lakasoks { get; set; } = new List<Lakasok>();

    public virtual Megyek? Megye { get; set; } = null!;
}

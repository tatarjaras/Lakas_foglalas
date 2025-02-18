using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LakasfoglalasBackEnd.Models;

public partial class User
{
    public int Id { get; set; }

    public string LoginNev { get; set; } = null!;

    public string Hash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int PermissionId { get; set; }

    public bool Active { get; set; }

    public string Email { get; set; } = null!;

    public string ProfilePicturePath { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Eladasok> Eladasoks { get; set; } = new List<Eladasok>();
    [JsonIgnore]
    public virtual ICollection<Lakasok> Lakasoks { get; set; } = new List<Lakasok>();
}

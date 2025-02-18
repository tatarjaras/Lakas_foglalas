using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;

namespace LakasfoglalasBackEnd.Models;

public partial class Eladasok
{
    public int Id { get; set; }

    public int FelhasznaloId { get; set; }

    public int LakasId { get; set; }

    public virtual User? Felhasznalo { get; set; } = null!;

    public virtual Lakasok? Lakas { get; set; } = null!;
}

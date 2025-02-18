using LakasfoglalasLoginClient.Models;
using System;
using System.Collections.Generic;

namespace LakasfoglalasBackEnd.Models;

public partial class Lakasok
{
    public int Id { get; set; }

    public string Utca { get; set; } = null!;

    public int Meret { get; set; }

    public int SzobakSzama { get; set; }

    public int Ar { get; set; }

    public string Leiras { get; set; } = null!;

    public int FelhasznaloId { get; set; }

    public int VarosId { get; set; }

    public bool Eladasoks { get; set; }

    public virtual User? Felhasznalo { get; set; } = null!;

    public virtual Varosok? Varos { get; set; } = null!;
}

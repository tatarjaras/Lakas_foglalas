using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LakasfoglalasLakasClient.Models
{
    public partial class Lakas
    {
        public int Id { get; set; }
        public string Utca { get; set; } = null!;
        public int Meret { get; set; } 
        public int Szobak_szama {  get; set; } 
        public int Ar {  get; set; } 
        public string Leiras {  get; set; } = null!;
        public int FelhasznaloID {  get; set; } 
        public int VarosID {  get; set; } 
        public bool Eladva { get; set; } 

    }
}

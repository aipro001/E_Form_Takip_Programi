using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talas_Belediyesi_HareketAmirligi_Takip
{
    internal class BaglantiSinifi
    {
        public string Adres = System.IO.File.ReadAllText(@"C:\HareketTakip.txt");
    }
}

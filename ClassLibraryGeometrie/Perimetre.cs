using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryGeometrie
{
    public class Perimetre
    {
        public double PerimetreRectagle(double longueur, double largeur)
        {
            return (longueur + largeur) * 2;
        }
    }
}

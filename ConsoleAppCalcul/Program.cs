using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalcul
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("La somme de 4 et 5 = {0}", (new Calcul()).Addition(4, 5));
            Console.ReadKey();
        }
    }
}

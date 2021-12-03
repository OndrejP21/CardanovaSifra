using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardanovaSifra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string plainText = "Ahoj vole jak se mas";
            /*Cardan cardan = new Cardan(plainText);
            cardan.Print();*/
            CardanLinked cardan = new CardanLinked(plainText);
            cardan.Print();
            Console.ReadKey();
        }
    }
}

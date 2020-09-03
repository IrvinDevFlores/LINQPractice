
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proyecto1LinQ
{
    class Program
    {

        static Menu menu = new Menu();
        static void Main(string[] args)
        {
            menu.ShowMenu();
            //string mystr = "898mbp9s";
            //Regex rex = new Regex(@"[0-9]*");
            //Match numero = rex.Match(mystr);

            Console.ReadKey();//El metodo 6 duplica los datos
        }
        //
               //

    }
}

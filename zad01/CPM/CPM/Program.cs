using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    class Program
    {
        static void Main(string[] args)
        {

            Dane.Wczytaj("dane.txt");
            ManagerZadan.WyswietlenieSciezkiKrytycznej();
            Console.WriteLine("--------------------------------------");
            //ManagerZadan.WyswietlenieWszystkichZadan();
            Console.ReadKey();

            
        }
    }
}

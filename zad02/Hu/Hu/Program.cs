using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class Program
    {
        static void Main(string[] args)
        {

            Dane.Wczytaj("dane3.txt");
            //ManagerZadan.WyswietlenieWszystkichZadan();
            ManagerZadan.UstawianiePoziomow();
            //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

           // ManagerZadan.WyswietlenieWszystkichZadan();

            ManagerMaszyn.PrzygotowanieHarmonogramu();

           // ManagerZadan.WyswietlenieWszystkichZadan();


            ManagerMaszyn.WyswietlHarmonogram();
            
            

            Console.ReadKey();


        }
    }
}

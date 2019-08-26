using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyJohnson
{
    class Program
    {
        static void Main(string[] args)
        {
            Dane.Wczytaj("dane.txt");
            //ManagerZadan.WyswietlenieWszystkichZadan();
            ManagerZadan.UstawianieListZmodyfikowanychCzasow();
           // if(ManagerZadan.SprawdzenieDanych()==true)
            ManagerZadan.UstawienieNaMaszynach();
            ManagerZadan.WyswietlenieZadan(ManagerZadan.M2);
           // ManagerZadan.WyswietlMaszyny();
            Console.ReadKey();
        }   
    }
}

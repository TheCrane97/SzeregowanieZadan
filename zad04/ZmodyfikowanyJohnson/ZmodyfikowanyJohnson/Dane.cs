using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZmodyfikowanyJohnson
{


    public class Dane
    {

        public static void Wczytaj(string plik)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Uczelnia\semestr_6\SzeregowanieZadan\zad04\ZmodyfikowanyJohnson\" + plik);

            for(int i=0;i<lines.Length;i+=4)
            {
                int numerZadania = Int32.Parse(lines[i]);
                int czasM1 = Int32.Parse(lines[i + 1]);
                int czasM2 = Int32.Parse(lines[i + 2]);
                int czasM3 = Int32.Parse(lines[i + 3]);

                Zadanie z = new Zadanie(numerZadania,czasM1,czasM2,czasM3);
                ManagerZadan.zadania.Add(z);

            }

        }

        
            
        




    }
}

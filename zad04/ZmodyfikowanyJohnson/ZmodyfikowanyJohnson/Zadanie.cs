using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyJohnson
{
    public class Zadanie
    {
        public int numerZadania;
        public int czasM1;
        public int czasM2;
        public int czasM3;
        public int zmodyfikowany1;
        public int zmodyfikowany2;
        public int wybrany;
        public int czasRozpoczecia;
        public int czasZakonczenia;

        public Zadanie()
        {
        }
        public Zadanie(int numerZadania, int czasM1, int czasM2, int czasM3)
        {
            this.numerZadania = numerZadania;
            this.czasM1 = czasM1;
            this.czasM2 = czasM2;
            this.czasM3 = czasM3;
            this.zmodyfikowany1 = czasM1+czasM2;
            this.zmodyfikowany2 = czasM2 + czasM3;
            if (zmodyfikowany1 > zmodyfikowany2)
                wybrany = zmodyfikowany2;
            else
                wybrany = zmodyfikowany1;

            
        }



        public void WyswietlDaneOZadaniu()
        {
            Console.WriteLine("Numer zadania:" + numerZadania);
            Console.WriteLine("Czas trwania na M1:" + czasM1);
            Console.WriteLine("Czas trwania na M2:" + czasM2);
            Console.WriteLine("Czas trwania na M3:" + czasM3);
            Console.WriteLine("Czas zmodyfikowany 1: " + zmodyfikowany1);
            Console.WriteLine("Czas zmodyfikowany 2: " + zmodyfikowany2);
            Console.WriteLine("Czas rozpoczecia: " + czasRozpoczecia);
            Console.WriteLine("Czas zakonczenia: " + czasZakonczenia);
            Console.WriteLine("---------------------------------------------------------------");
        }

    }
}

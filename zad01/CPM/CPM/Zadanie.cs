using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    class Zadanie
    {
        public int numerZadania;
        public int czasTrwania;
        public int czasRozpoczecia;
        public int czasZakonczenia;
        public List<Zadanie>poprzednieZadania = new List<Zadanie>();
        public List<Zadanie>nastepneZadania = new List<Zadanie>();

        public Zadanie()
        {


        }
        public Zadanie(int numerZadania, int czasTrwania, int czasRozpoczecia, int czasZakonczenia, List<Zadanie> poprzednieZadania,List<Zadanie> nastepneZadania)
        {
            this.numerZadania = numerZadania;
            this.czasTrwania = czasTrwania;
            this.czasRozpoczecia = czasRozpoczecia;
            this.czasZakonczenia = czasZakonczenia;
            this.poprzednieZadania = poprzednieZadania;
            this.nastepneZadania = nastepneZadania;
        }



        public void WyswietlDaneOZadaniu()
        {
            Console.WriteLine("Numer zadania:" + numerZadania);
            Console.WriteLine("Czas trwania:" + czasTrwania);
           // Console.WriteLine("Czas rozpoczecia:" + czasRozpoczecia);
           // Console.WriteLine("Czas zakonczenia:" + czasZakonczenia);

            Console.Write("Zadania nastepne:");
            foreach(Zadanie z in nastepneZadania)
                Console.Write( z.numerZadania+" ");

            Console.WriteLine();

            Console.Write("Zadania poprzednie:");
            foreach (Zadanie z in poprzednieZadania)
                Console.Write(+ z.numerZadania+" ");

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------");
        }

    }
}

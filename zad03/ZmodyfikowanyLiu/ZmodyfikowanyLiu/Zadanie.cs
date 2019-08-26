using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyLiu
{
    public class Zadanie
    {
        public int numerZadania;
        public int czasTrwania;
        public int czasRozpoczecia;
        public int czasZakonczenia;
        public int oczekiwanyCzasZakonczenia;
        public int czasPrzyjsciaDoSystemu;
        public int zmodyfikowanyCzasZakonczenia;
        public List<Zadanie> poprzednieZadania = new List<Zadanie>();
        public List<Zadanie> nastepneZadania = new List<Zadanie>();
        public bool sprawdz = false;

        public Zadanie()
        {


        }
        public Zadanie(int numerZadania,int czasRozpoczecia,int czasZakonczenia)
        {
            this.numerZadania = numerZadania;
            this.czasRozpoczecia = czasRozpoczecia;
            this.czasZakonczenia = czasZakonczenia;
        }

        public Zadanie(int numerZadania, int czasTrwania, int oczekiwanyCzasZakonczenia, int czasPrzyjsciaDoSystemu, List<Zadanie> poprzednieZadania, List<Zadanie> nastepneZadania)
        {
            this.numerZadania = numerZadania;
            this.czasTrwania = czasTrwania;
            this.oczekiwanyCzasZakonczenia = oczekiwanyCzasZakonczenia;
            this.czasPrzyjsciaDoSystemu = czasPrzyjsciaDoSystemu;
            this.poprzednieZadania = poprzednieZadania;
            this.nastepneZadania = nastepneZadania;
        }

        public void WyswietlDaneOZadaniuZMaszyny()
        {
            Console.WriteLine("Numer zadania:" + numerZadania);
            Console.WriteLine("Czas rozpoczecia: " + czasRozpoczecia);
            Console.WriteLine("Czas zakonczenia: " + czasZakonczenia);
            Console.WriteLine("---------------------------------------------------------------");
        }



        public void WyswietlDaneOZadaniu()
        {
            Console.WriteLine("Numer zadania:" + numerZadania);

            Console.WriteLine("Czas trwania:" + czasTrwania);
            Console.WriteLine("Oczekiwany czas zakonczenia:" + oczekiwanyCzasZakonczenia);
            Console.WriteLine("Czas przyjscia do systemu:" + czasPrzyjsciaDoSystemu);
            Console.WriteLine("Zmodyfikowany czas zakonczenia:" + zmodyfikowanyCzasZakonczenia);


            Console.Write("Zadania nastepne:");
            foreach (Zadanie z in nastepneZadania)
                Console.Write(z.numerZadania + " ");

            Console.WriteLine();

            Console.Write("Zadania poprzednie:");
            foreach (Zadanie z in poprzednieZadania)
                Console.Write(+z.numerZadania + " ");

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------");
        }
    }
}

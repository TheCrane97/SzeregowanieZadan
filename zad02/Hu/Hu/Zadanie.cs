using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class Zadanie
    {
        public int numerZadania;
        public int czasTrwania;
        public int poziom;
        public List<Zadanie> poprzednieZadania = new List<Zadanie>();
        public List<Zadanie> nastepneZadania = new List<Zadanie>();
        public Boolean czyZakonczone=false;

        public Zadanie(){}

        public Zadanie(int numerZadania, int czasTrwania,int poziom, List<Zadanie> poprzednieZadania, List<Zadanie> nastepneZadania,Boolean status)
        {
            this.numerZadania = numerZadania;
            this.czasTrwania = czasTrwania;
            this.poziom = poziom;
            this.poprzednieZadania = poprzednieZadania;
            this.nastepneZadania = nastepneZadania;
            this.czyZakonczone = status;

        }



        public void WyswietlDaneOZadaniu()
        {
            Console.WriteLine("Numer zadania:" + numerZadania);
            Console.WriteLine("Czas trwania:" + czasTrwania);
            Console.WriteLine("Poziom:" + poziom);

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

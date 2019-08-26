using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPM
{
    class ManagerZadan
    {
        public static List<Zadanie> zadania = new List<Zadanie>();

        public static void LiczenieCzasow()
        {

            foreach (Zadanie zadanie in zadania)
            {
                foreach (Zadanie poprzednik in zadanie.poprzednieZadania)
                {
                    if (zadanie.numerZadania == poprzednik.numerZadania)
                    {
                        poprzednik.czasRozpoczecia=zadanie.czasRozpoczecia;
                        poprzednik.czasZakonczenia = zadanie.czasZakonczenia;
                    }
                }

                if (zadanie.poprzednieZadania.Count()==0)
                {
                    zadanie.czasRozpoczecia = 0 ;
                    zadanie.czasZakonczenia = zadanie.czasTrwania;
                }
                else
                {
                    int[] koncoweCzasy = new int[zadanie.poprzednieZadania.Count()];
                    for (int i = 0; i < zadanie.poprzednieZadania.Count(); i++)
                    {
                        koncoweCzasy[i] = zadanie.poprzednieZadania.ElementAt(i).czasZakonczenia;
                    }

                    int max = koncoweCzasy.Max();
                    zadanie.czasRozpoczecia = max;
                    zadanie.czasZakonczenia = zadanie.czasRozpoczecia + zadanie.czasTrwania;
                }
            }




        }

        public static void ZnajdzSciezkeKrytyczna(List<Zadanie> zadania, List<Zadanie> ostatecznaSciezka )
        {
            Zadanie max = new Zadanie();
            foreach (Zadanie zad in zadania)
            {
                if (zad.czasZakonczenia > max.czasZakonczenia)
                {
                   max=zad;
                }
            }
            ostatecznaSciezka.Add(max);
            if (max.poprzednieZadania.Count()!=0)
            {
                ZnajdzSciezkeKrytyczna(max.poprzednieZadania, ostatecznaSciezka);
            }
        }

        public static void WyswietlenieSciezkiKrytycznej()
        {
            LiczenieCzasow();
            List<Zadanie> ostatecznaSciezka = new List<Zadanie>();
            ZnajdzSciezkeKrytyczna(zadania, ostatecznaSciezka);
            Console.WriteLine("Czas: " + ostatecznaSciezka.ElementAt(0).czasZakonczenia);

            ostatecznaSciezka.Reverse();

            Console.Write("Sciezka krytyczna: ");
            int x = 0;
            foreach (Zadanie zadanie in ostatecznaSciezka)
            {
                if (x == ostatecznaSciezka.Count()-1)
                {
                    Console.Write("Z" + zadanie.numerZadania);
                    break;
                }
                Console.Write("Z" + zadanie.numerZadania + "->");
                x++;
            }
            Console.WriteLine();
        }


        public static void WyswietlenieWszystkichZadan()
        {
            foreach (Zadanie z in zadania)
                z.WyswietlDaneOZadaniu();
        }

    }
}

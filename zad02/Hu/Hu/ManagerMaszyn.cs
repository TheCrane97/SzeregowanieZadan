using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class ManagerMaszyn
    {
        public static List<Maszyna> maszyny = new List<Maszyna>();

        public static int Porownaj(Zadanie zad1, Zadanie zad2)
        {
                return zad2.poziom- zad1.poziom;   
        }

        internal static void WyswietlHarmonogram()
        {
            foreach(Maszyna m in maszyny)
            {
                Console.Write("Maszyna numer " + m.numerMaszyny + " : ");
                foreach(Zadanie z in m.ustawienieZadan)
                {
                    if(z.numerZadania==0)
                        Console.Write("   ");
                    else
                        Console.Write("Z" + z.numerZadania + " ");
                }
                Console.WriteLine();

            }
        }

        public static void PrzygotowanieHarmonogramu()
        {
            int time = 0;
            
            if (ManagerZadan.StatusWDrzewie == "out-tree")
            {
                
                foreach (Zadanie zadanie in ManagerZadan.zadania)
                {
                    List<Zadanie> tymczasowa = new List<Zadanie>();
                    if (zadanie.poprzednieZadania.Count()!=0)
                    {
                        foreach (Zadanie poprzednie in zadanie.poprzednieZadania)
                        {
                            tymczasowa = zadanie.poprzednieZadania;
                            zadanie.nastepneZadania.Add(poprzednie);
                            poprzednie.poprzednieZadania.Add(zadanie);
                        }
                        zadanie.poprzednieZadania = new List<Zadanie>();
                    }
                    zadanie.nastepneZadania = tymczasowa;
                }

                ManagerZadan.UstawianiePoziomow();
                
            }


           


            while (!ManagerZadan.UkonczoneZadania(ManagerZadan.zadania,0))
            {
                int maxLevel = ManagerZadan.zadania.First().poziom;
                List<Zadanie> zadaniaBezPoprzednich = new List<Zadanie>();
                List<Zadanie> zadaniaDoWykonania = new List<Zadanie>();

                foreach (Zadanie zadanie in ManagerZadan.zadania)
                {
                    if (zadanie.poprzednieZadania.Count()==0 && zadanie.czyZakonczone==false)
                    {
                        zadaniaBezPoprzednich.Add(zadanie);
                    }
                }

                zadaniaBezPoprzednich.Sort(Porownaj);


                if (zadaniaBezPoprzednich.Count() <= maszyny.Count())
                {
                    zadaniaDoWykonania = zadaniaBezPoprzednich;
                    while (zadaniaDoWykonania.Count() < maszyny.Count())
                    {
                        zadaniaDoWykonania.Add(new Zadanie(0, 1, 0, new List<Zadanie>(), new List<Zadanie>(), false));
                    }
                }
                else
                {
                    for (int i = 0; i < maszyny.Count(); i++)
                    {
                        zadaniaDoWykonania.Insert(i, zadaniaBezPoprzednich.ElementAt(i));
                    }
                }

                for (int i = 0; i < zadaniaDoWykonania.Count(); i++)
                {
                    maszyny.ElementAt(i).ustawienieZadan.Add(zadaniaDoWykonania.ElementAt(i));
                    
                    Zadanie zadanieDoWykonania = zadaniaDoWykonania.ElementAt(i);
                    ManagerZadan.ZakonczZadanie(zadanieDoWykonania.numerZadania);
                }
                time++;
            }

            if (ManagerZadan.StatusWDrzewie == "out-tree")
            {
                foreach (Maszyna m in maszyny)
                {
                    m.ustawienieZadan.Reverse();
                }
            }
        }
    }
}

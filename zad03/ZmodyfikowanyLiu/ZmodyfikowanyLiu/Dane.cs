using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyLiu
{
    public class Dane
    {
        public static void Wczytaj(string plik)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Uczelnia\semestr_6\SzeregowanieZadan\zad03\ZmodyfikowanyLiu\" + plik);

            for (int i = 0; i < lines.Length; i += 5)
            {
                int numerZadania = Int32.Parse(lines[i]);
                int czasTrwania = Int32.Parse(lines[i + 1]);
                int oczekiwanyCzasZakonczenia = Int32.Parse(lines[i+3]);
                int czasPrzyjsciaDoSystemu = Int32.Parse(lines[i + 4]);

                Zadanie z = new Zadanie(numerZadania, czasTrwania, oczekiwanyCzasZakonczenia,czasPrzyjsciaDoSystemu, new List<Zadanie>(), new List<Zadanie>());
                ManagerZadan.zadania.Add(z);

            }



            int j = 0;
            for (int i = 2; i < lines.Length; i += 5)
            {

                List<string> zadaniaPoprzednie = new List<string>();
                foreach (string zad in lines[i].Split(' '))
                {
                    zadaniaPoprzednie.Add(zad);
                }

                foreach (string zad in zadaniaPoprzednie)
                {

                    if (int.TryParse(zad, out int a))
                    {
                        int b = Convert.ToInt32(zad);
                        ManagerZadan.zadania.ElementAt(j).poprzednieZadania.Add(ManagerZadan.zadania.ElementAt(b - 1));
                        ManagerZadan.zadania.ElementAt(b - 1).nastepneZadania.Add(ManagerZadan.zadania.ElementAt(j));
                    }
                }

                j++;
            }



        }
    }
}

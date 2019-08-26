using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class Dane
    {
        public static void Wczytaj(string plik)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Uczelnia\semestr_6\SzeregowanieZadan\zad02\Hu\" + plik);


            for(int i=1;i<= Int32.Parse(lines[0]); i++)
            {
                Maszyna m = new Maszyna(i, new List<Zadanie>());
                ManagerMaszyn.maszyny.Add(m);

            }

            for (int i = 1; i < lines.Length; i += 2)
            {
                int numerZadania = Int32.Parse(lines[i]);

                Zadanie z = new Zadanie(numerZadania, 1, 0, new List<Zadanie>(), new List<Zadanie>(),false);
                ManagerZadan.zadania.Add(z);

            }



            int j = 0;
            for (int i = 2; i < lines.Length; i += 2)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyJohnson
{
    public class ManagerZadan
    {
        public static List<Zadanie> zadania = new List<Zadanie>();
        public static List<Zadanie> zmodyfikowaneM1 = new List<Zadanie>();
        public static List<Zadanie> zmodyfikowaneM2= new List<Zadanie>();
        public static List<Zadanie> M1 = new List<Zadanie>();
        public static List<Zadanie> M2 = new List<Zadanie>();
        public static List<Zadanie> M3 = new List<Zadanie>();

        public static void WyswietlenieZadan(List<Zadanie> lista)
        {
            foreach (Zadanie z in lista)
                z.WyswietlDaneOZadaniu();
        }

        public static void WyswietlMaszyny()
        {
            Console.Write("M1:");
            for(int j=0;j<M1.Count();j++)
            {

                if(j==0)
                {
                    if (M1.ElementAt(j).czasRozpoczecia != 0)
                        for (int i = 0; i < M1.ElementAt(j).czasRozpoczecia; i++)
                            Console.Write("  ");
                }


                if(j<M1.Count()-1)
                if(M1.ElementAt(j+1).czasRozpoczecia - M1.ElementAt(j).czasZakonczenia!=0)
                {
                    
                        for (int i = 0; i < M1.ElementAt(j + 1).czasRozpoczecia - M1.ElementAt(j).czasZakonczenia; i++)
                            Console.Write("   ");

                        Console.Write("|");

                    
                }
                    Console.Write(" Z" + M1.ElementAt(j).numerZadania);
                    for (int i = 0; i < M1.ElementAt(j).czasM1-1; i++)
                        Console.Write("    ");

                    Console.Write("|");

            }
            Console.WriteLine();


            Console.Write("M2:");
            for (int j = 0; j < M2.Count(); j++)
            {
                if (j == 0)
                {
                    if (M2.ElementAt(j).czasRozpoczecia != 0)
                        for (int i = 0; i < M2.ElementAt(j).czasRozpoczecia; i++)
                            Console.Write(" ");
                }

                if (j < M2.Count() - 1)
                    if (M2.ElementAt(j + 1).czasRozpoczecia - M2.ElementAt(j).czasZakonczenia != 0)
                    {

                        for (int i = 0; i < M2.ElementAt(j + 1).czasRozpoczecia - M2.ElementAt(j).czasZakonczenia; i++)
                            Console.Write(" ");

                        Console.Write("|");


                    }
                Console.Write(" Z" + M2.ElementAt(j).numerZadania);
                for (int i = 0; i < M2.ElementAt(j).czasM2 - 1; i++)
                    Console.Write("  ");

                Console.Write("|");

            }
            Console.WriteLine();


            Console.Write("M3:");
            for (int j = 0; j < M3.Count(); j++)
            {
                if (j == 0)
                {
                    if (M3.ElementAt(j).czasRozpoczecia != 0)
                        for (int i = 0; i < M3.ElementAt(j).czasRozpoczecia; i++)
                            Console.Write(" ");
                }

                if (j < M3.Count() - 1)
                    if (M3.ElementAt(j + 1).czasRozpoczecia - M3.ElementAt(j).czasZakonczenia != 0)
                    {

                        for (int i = 0; i < M3.ElementAt(j + 1).czasRozpoczecia - M3.ElementAt(j).czasZakonczenia; i++)
                            Console.Write("  ");

                        Console.Write("|");


                    }
                Console.Write(" Z" + M3.ElementAt(j).numerZadania);
                for (int i = 0; i < M3.ElementAt(j).czasM3 - 1; i++)
                    Console.Write(" ");

                Console.Write("|");

            }
            Console.WriteLine();


            int os = 0;

            foreach(Zadanie zad in M1)
            {
                if (zad.czasZakonczenia > os)
                    os = zad.czasZakonczenia;

            }

            foreach (Zadanie zad in M2)
            {
                if (zad.czasZakonczenia > os)
                    os = zad.czasZakonczenia;

            }

            foreach (Zadanie zad in M3)
            {
                if (zad.czasZakonczenia > os)
                    os = zad.czasZakonczenia;

            }

           
            for(int i =0; i<os;i++)
            {
                Console.Write("   " + i);
            }

        }

        public static bool SprawdzenieDanych()
        {
            bool status = true;
            int min1 = 5000;
            int min3 = 5000;
            int max=0;


            foreach(Zadanie zad in zadania)
            {
                if(max<zad.czasM2 )
                    max = zad.czasM2;
                

                if (min1 > zad.czasM1)
                    min1 = zad.czasM1;
                if (min3 > zad.czasM3)
                    min3 = zad.czasM3;
            }


            if (min1 >= max || min3 >= max)
                return true;
            else
                return false;
           


        }


        public static void UstawianieListZmodyfikowanychCzasow()
        {
            foreach (Zadanie zad in zadania)
            {
                if (zad.zmodyfikowany1 > zad.zmodyfikowany2)
                {
                    
                    zad.wybrany = zad.zmodyfikowany2;
                    zmodyfikowaneM2.Add(zad);
                }

                else
                {
                    zad.wybrany = zad.zmodyfikowany1;
                    zmodyfikowaneM1.Add(zad);
                }



            }

            zmodyfikowaneM1 = zmodyfikowaneM1.OrderBy(zad => zad.wybrany).ToList();
            zmodyfikowaneM2 = zmodyfikowaneM2.OrderByDescending(zad => zad.wybrany).ToList();

        }



        public static void UstawienieNaMaszynach()
        {
            int osM1 = 0;
            int osM2 = 0;
            int osM3 = 0;

            foreach (Zadanie zad in zmodyfikowaneM1)
            {
                Zadanie z = new Zadanie(zad.numerZadania, zad.czasM1,zad.czasM2,zad.czasM3);
                z.czasRozpoczecia = osM1;
                z.czasZakonczenia = osM1 + z.czasM1;
                osM1 += z.czasM1;
                M1.Add(z);


                Zadanie za = new Zadanie(zad.numerZadania, zad.czasM1, zad.czasM2, zad.czasM3);
                if (osM2 < osM1)
                    osM2 = osM1;
                za.czasRozpoczecia = osM2;
                za.czasZakonczenia = osM2 + za.czasM2;
                osM2 += za.czasM2;
                M2.Add(za);

                Zadanie zada = new Zadanie(zad.numerZadania, zad.czasM1, zad.czasM2, zad.czasM3);
                if (osM3 < osM2)
                    osM3 = osM2;
                zada.czasRozpoczecia = osM3;
                zada.czasZakonczenia = osM3 + zada.czasM3;
                osM3 += zada.czasM3;
                M3.Add(zada);


            }

            foreach (Zadanie zad in zmodyfikowaneM2)
            {
                Zadanie z = new Zadanie(zad.numerZadania, zad.czasM1, zad.czasM2, zad.czasM3);
                z.czasRozpoczecia = osM1;
                z.czasZakonczenia = osM1 + z.czasM1;
                osM1 += z.czasM1;
                M1.Add(z);



                Zadanie za = new Zadanie(zad.numerZadania, zad.czasM1, zad.czasM2, zad.czasM3);
                if (osM2 < osM1)
                    osM2 = osM1;
                za.czasRozpoczecia = osM2;
                za.czasZakonczenia = osM2 + za.czasM2;
                osM2 += za.czasM2;
                M2.Add(za);

                Zadanie zada = new Zadanie(zad.numerZadania, zad.czasM1, zad.czasM2, zad.czasM3);
                if(osM3<osM2)
                osM3 = osM2;
                zada.czasRozpoczecia = osM3;
                zada.czasZakonczenia = osM3 + zada.czasM3;
                osM3 += za.czasM3;
                M3.Add(zada);


            }

           

        }
    }
}

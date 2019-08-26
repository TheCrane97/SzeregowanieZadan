using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZmodyfikowanyLiu
{
    public class ManagerZadan
    {
        public static List<Zadanie> zadania = new List<Zadanie>();
        public static List<int> minimalna = new List<int>();
        public static List<Zadanie> maszyna = new List<Zadanie>();
        public static List<Zadanie> ulozoneZadania = new List<Zadanie>();
        public static int os = 0;
        public static List<int> opoznienie = new List<int>();
        public static bool status = true;



        public static void Acyklicznosc()
        {
            foreach(Zadanie zad in zadania)
            {
                zad.sprawdz = true;
            }


            foreach(Zadanie zad in zadania)
            {
                if (status == false)
                    break;
                foreach (Zadanie z in zad.nastepneZadania)
                {
                    if (z.sprawdz == true)
                    {
                        status = false;
                        break;
                    }
                }


            }

        }

        public static void WyswietlenieWszystkichZadan()
        {
            foreach (Zadanie z in zadania)
                z.WyswietlDaneOZadaniu();
        }


        public static void WyswietlenieMaszyny()
        {
            foreach (Zadanie z in maszyna)
                z.WyswietlDaneOZadaniuZMaszyny();
        }


        public static void SzukanieCzasowZakonczenia(Zadanie zad, List<Zadanie> nastepniki)
        {
        
            if(minimalna.Count()==0)
            {
                minimalna.Add(zad.oczekiwanyCzasZakonczenia);
            }
            
            foreach(Zadanie zadanie in nastepniki)
            {
                minimalna.Add(zadanie.oczekiwanyCzasZakonczenia);
                SzukanieCzasowZakonczenia(zad, zadanie.nastepneZadania);
            }
            
        }



        public static void UstawienieZmodyfikowanychCzasowZakonczenia()
        {
            foreach (Zadanie zad in zadania)
            {
                SzukanieCzasowZakonczenia(zad, zad.nastepneZadania);
                zad.zmodyfikowanyCzasZakonczenia = minimalna.Min();
                minimalna.Clear();
            }
        }



        public static List<Zadanie> AktualneZadaniaDoWykonania(int czas,List<Zadanie> lista)
        {

            foreach(Zadanie z in ulozoneZadania)
            {
                if (z.czasPrzyjsciaDoSystemu == czas)
                    lista.Add(z);
            }

            return lista;
        }





        public static bool CzyKoniec()
        {
            foreach (Zadanie z in ulozoneZadania)
            {
                if (z.czasTrwania > 0)
                    return false;
            }

            return true;
        }


        public static void UstawienieZadanNaMaszynie()
        {

            ulozoneZadania = zadania.OrderBy(zad => zad.czasPrzyjsciaDoSystemu).ToList();
            List<Zadanie> aktualne = new List<Zadanie>();
            int min = 100000;
            os = 0;
            int pom;
            while(true)
            {
                if (CzyKoniec() == false)
                { 
                    aktualne = AktualneZadaniaDoWykonania(os,aktualne);

                    int i = 0;
                   while(true)
                    {

                       // WyswietlenieMaszyny();


                        if (CzyKoniec() == true)
                            break;

                        

                        for (int k = 0; k < aktualne.Count(); k++)
                        {
                            if (min > aktualne.ElementAt(k).zmodyfikowanyCzasZakonczenia && aktualne.ElementAt(k).czasTrwania!=0)
                            {
                                min = aktualne.ElementAt(k).zmodyfikowanyCzasZakonczenia;
                                i = k;
                            }
                        }
                        min = 5000000;
                        Znalazlo:
                        if (aktualne.Count() != 0)
                        { 
                            if (aktualne.ElementAt(i).poprzednieZadania.Count() == 0 && aktualne.ElementAt(i).czasTrwania != 0)
                            {


                                    Zadanie z = new Zadanie(aktualne.ElementAt(i).numerZadania, os, os + 1);
                                    aktualne.ElementAt(i).czasTrwania -= 1;
                                    maszyna.Add(z);
                                
                                


                            }
                            else
                            {
                                for (int j = 0; j < aktualne.ElementAt(i).poprzednieZadania.Count(); j++)
                                {
                                    pom = aktualne.IndexOf(aktualne.ElementAt(i).poprzednieZadania.ElementAt(j));
                                    if (pom!=-1)
                                    {
                                        if(aktualne.ElementAt(pom).czasTrwania>0)
                                        {
                                                i = pom;
                                                goto Znalazlo;
                                        }
                                    }
                                    else
                                    {
                                        goto Dalej;
                                    }
                                }

                                    if(aktualne.ElementAt(i).czasTrwania != 0)
                                    {
                                        Zadanie z = new Zadanie(aktualne.ElementAt(i).numerZadania, os, os + 1);
                                        aktualne.ElementAt(i).czasTrwania -= 1;
                                        maszyna.Add(z);
                                    
                                    
                                    }


                            }
                        }
                    Dalej:
                        os += 1;
                        aktualne = AktualneZadaniaDoWykonania(os, aktualne);




                    }
                    

                }
                else
                {
                    break;
                }


            }

            
        }


        public static int WyliczenieOpoznienia()
        {
            int czasZakonczenia=0;
            for(int i=1;i<=zadania.Count();i++)
            {
                foreach(Zadanie z in maszyna)
                {
                    if (z.numerZadania == i)
                        czasZakonczenia = z.czasZakonczenia;
                }

                opoznienie.Add(czasZakonczenia - zadania.ElementAt(i - 1).oczekiwanyCzasZakonczenia);
            }


            if (opoznienie.Max() < 0)
                return 0;
            else
                return opoznienie.Max();


        }


    }
}

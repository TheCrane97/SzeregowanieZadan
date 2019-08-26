using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hu
{
    class ManagerZadan
    {
        public static List<Zadanie> zadania = new List<Zadanie>();
        public static string StatusWDrzewie;
       
        public static void WyswietlenieWszystkichZadan()
        {
            foreach (Zadanie z in zadania)
                z.WyswietlDaneOZadaniu();
        }


        public static void UstawianiePoziomow()
        {
            zadania.Reverse();

            foreach (Zadanie zadanie in zadania)
            {
                zadanie.poziom=0;
            }

            
            for(int i=0;i<zadania.Count();i++)
            {
                Zadanie zad = zadania.ElementAt(i);
                if (StatusWDrzewie == "out-tree")
                {
                    zadania.Reverse();
                    if (zad.poprzednieZadania.Count()==0)
                    {
                        zad.poziom=1;
                    }
                    else
                    {
                        zad.poziom=zad.poprzednieZadania.ElementAt(0).poziom + 1;
                    }
                    zadania.Reverse();
                }
                else
                {
                    if (zad.nastepneZadania.Count()==0)
                    {
                        zad.poziom=1;
                    }
                    else
                    {
                        zad.poziom=zad.nastepneZadania.ElementAt(0).poziom + 1;
                    }
                }
            }
            zadania.Reverse();

            int maxLevel = 0;
            foreach (Zadanie zadanie in zadania)
            {
                if (zadanie.poziom > maxLevel) maxLevel = zadanie.poziom;
            }

            int minCounter = 0;
            int maxCounter = 0;
            foreach(Zadanie zadanie in zadania)
            {
                if (zadanie.poziom == 1) minCounter++;
                if (zadanie.poziom == maxLevel) maxCounter++;
            }

            if (minCounter > maxCounter) StatusWDrzewie = "out-tree";
            if (minCounter < maxCounter) StatusWDrzewie = "in-tree";
            
        }

        public static Boolean UkonczoneZadania(List<Zadanie> zad,int licznik)
        {

            foreach(Zadanie zadanie in zad)
            {
                if (!zadanie.czyZakonczone)
                    licznik++;
                UkonczoneZadania(zadanie.poprzednieZadania, licznik);
            }

            if (licznik == 0)
                return true;
            else
                return false;

        }

        public static void ZakonczZadanie(int numer)
        {
            Zadanie doUsuniecia = new Zadanie();
            foreach (Zadanie zad in zadania)
            {
                if (zad.numerZadania == numer)
                {
                    zad.czyZakonczone=true;
                    doUsuniecia = zad;
                    break;
                }
            }
            zadania.Remove(doUsuniecia);

            foreach (Zadanie zadanie in zadania)
            {
                if (zadanie.poprzednieZadania.Contains(doUsuniecia))
                    zadanie.poprzednieZadania.Remove(doUsuniecia);
                if (zadanie.nastepneZadania.Contains(doUsuniecia))
                    zadanie.nastepneZadania.Remove(doUsuniecia);
            }
        }
    }
}

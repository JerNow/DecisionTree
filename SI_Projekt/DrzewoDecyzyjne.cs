using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Projekt
{
    public class DrzewoDecyzyjne
    {

        //public bool TBoolean(string war)
        //{
        //    switch (war)
        //    {
        //        case "1":
        //            return true;

        //        case "0":
        //            return false;
        //        default:
        //            return false;
        //    }
        //}

        public bool TBoolean(string war)
        {
            switch (war)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    throw new ArgumentException();
            }    
        }

        public double FunkcjaLogarytmiczna(int pozytywI, int caloscI)
        {
            double pozI = pozytywI;
            double calI = caloscI;
            double podzielone = pozI / calI;
            double wynik = 0;
            double podzielone_log;
            if (podzielone > 0)
            {
                podzielone_log = Math.Log(podzielone, 2);
                wynik = (podzielone * (-1));
                wynik *= podzielone_log;
                return wynik;
            }
            else
                return wynik;
        }

        public double KoncowaEntropia(double entropiaKonkluzji, double entropiaPrzeslanki)
        {
            double wynik = entropiaKonkluzji - entropiaPrzeslanki;
            return wynik;
        }

    }
}

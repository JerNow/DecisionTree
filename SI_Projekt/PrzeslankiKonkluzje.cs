using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Projekt
{
    public class PrzeslankiKonkluzje
    {
        public string nazwa { get; set; }
        public List<bool> wartosci;
        public int grupa;
        public int indeksWGrupie;
        public static int licznikIndeksWGrupie=-1;
        public static int ostatniaGrupa = 1;
        public PrzeslankiKonkluzje(string nazwa, List<bool>wartosci, int grupa)
        {
            this.nazwa = nazwa;
            this.wartosci = wartosci;
            this.grupa = grupa;
            if(grupa == ostatniaGrupa)
            {
                licznikIndeksWGrupie++;
                this.indeksWGrupie = licznikIndeksWGrupie;
            }
            else
            {
                licznikIndeksWGrupie = 0;
                this.indeksWGrupie = licznikIndeksWGrupie;
                ostatniaGrupa++;
            }
        }

        public PrzeslankiKonkluzje(string nazwa, List<bool> wartosci, int grupa, int indeksWGrupie)
        {
            this.nazwa = nazwa;
            this.wartosci = wartosci;
            this.grupa = grupa;
            this.indeksWGrupie = indeksWGrupie;
        }

        public PrzeslankiKonkluzje()
        {
        }
    }
}

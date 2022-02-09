using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace SI_Projekt
{
    public class Program
    {
        public static bool TBoolean(string war)
        {
            switch (war)
            {
                case "1":
                    return true;
                case "0":
                    return false;
                default:
                    return false;
            }
        }
        public static double FunkcjaLogarytmiczna(int pozytywI, int caloscI)
        {
            double pozI = pozytywI;
            double calI = caloscI;
            double podzielone = pozI / calI;
            double wynik=0;
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
        
        public static double KonkluzjeLog(PrzeslankiKonkluzje PrzeKonList, out int indeks)
        {
            int pozytywI = 0, caloscI = 0;
            for (int j = 0; j < PrzeKonList.wartosci.Count; j++)
            {
                if (PrzeKonList.wartosci[j] == true) pozytywI++;
            }

            caloscI = PrzeKonList.wartosci.Count;

            double wyniklog = FunkcjaLogarytmiczna(pozytywI, caloscI);
            if(caloscI==pozytywI)
                indeks = 1;
            else
                indeks = 0;
            return wyniklog;

        }

        public static double EntropiaKonkluzji(List<PrzeslankiKonkluzje> ListaKonkluzji, out int indeksKonkluzji)
        {
            int indeksJPD = 0;
            indeksKonkluzji = 0;
            double wynik = 0;
            for(int i = 1; i<4; i++)
            {
                wynik += KonkluzjeLog(ListaKonkluzji[ListaKonkluzji.Count - i],out indeksJPD);
                if (indeksJPD == 1)
                {
                    indeksKonkluzji = ListaKonkluzji.Count - i;
                }
                else
                {
                    //indeksKonkluzji = 0;
                }
            }
            return wynik;
        }
        public static double PrzeslankiLog(PrzeslankiKonkluzje PrzeKonList, List<PrzeslankiKonkluzje> ListaPrzeslanek, bool czyPlus)
        {
            double wynikSuma = 0;
            for (int i = 3; i > 0; i--)
            {
                int pozytywI = 0, caloscI = 0;
                for (int j = 0; j < PrzeKonList.wartosci.Count; j++)
                {
                    if (PrzeKonList.wartosci[j] == czyPlus && ListaPrzeslanek[ListaPrzeslanek.Count - i].wartosci[j] == true)
                    {
                        pozytywI++;
                        caloscI++;
                    }
                    else if (PrzeKonList.wartosci[j] == czyPlus && ListaPrzeslanek[ListaPrzeslanek.Count - i].wartosci[j] == false)
                    {
                        caloscI++;
                    }
                }
                wynikSuma += FunkcjaLogarytmiczna(pozytywI, caloscI);
            }
            return wynikSuma;

        }

        public static double FaktycznaEntropia(PrzeslankiKonkluzje PrzeKonList, List<PrzeslankiKonkluzje> ListaPrzeslanek)
        {
            int pozytywI = 0, caloscI = 0, negatywI=0;

            for (int j = 0; j < PrzeKonList.wartosci.Count; j++)
            {
                if (PrzeKonList.wartosci[j] == true)
                    pozytywI++;
                else
                    negatywI++;

                caloscI++;

            }
            double pozI = pozytywI;
            double calI = caloscI;
            double negI = negatywI;
            double wynik = ((pozI / calI)*PrzeslankiLog(PrzeKonList, ListaPrzeslanek, true))+((negI/calI) * PrzeslankiLog(PrzeKonList, ListaPrzeslanek, false));
            return wynik;
        }
        /*
        public static double KoncowaEntropia(double entropiaKonkluzji, double entropiaPrzeslanki)
        {
            double wynik = entropiaKonkluzji - entropiaPrzeslanki;
            return wynik;
        }
        */
        public static double KoncowaEntropia(double entropiaKonkluzji, double entropiaPrzeslanki)
        {
            double wynik = entropiaKonkluzji - entropiaPrzeslanki;
            return wynik;
        }

        public static void Przelicz(List<PrzeslankiKonkluzje> PrzeKonList,int licznikRekurencji, int iloscGrup, string usuwanyWarunek)
        {
            int indeksKonkluzji = 0;
            double entropiaKonkluzji = EntropiaKonkluzji(PrzeKonList,out indeksKonkluzji);
            if (entropiaKonkluzji == 0)
            {
                Console.WriteLine(usuwanyWarunek + " decyzja: " + PrzeKonList[indeksKonkluzji].nazwa);
                //Console.WriteLine(usuwanyWarunek);
                //Console.WriteLine("decyzja: " + PrzeKonList[indeksKonkluzji].nazwa);
                //Console.WriteLine("");
                //Console.WriteLine("test" + licznikRekurencji);
                //Console.WriteLine(usuwanyWarunek + " " + drzewo);
                return;
            }
            double[] entropiaPrzeslanek = new double[PrzeKonList.Count-3];
            for (int i = 0; i< PrzeKonList.Count-3; i++)
            {
                entropiaPrzeslanek[i] = KoncowaEntropia(entropiaKonkluzji, FaktycznaEntropia(PrzeKonList[i], PrzeKonList));
            }
            double sprawdz = 0;
            int najwieksza = 0;
            for (int i = 0; i < PrzeKonList.Count - 3; i++)
            {
                //Console.WriteLine(entropiaPrzeslanek[i]);
                if (sprawdz < entropiaPrzeslanek[i])
                {
                    sprawdz = entropiaPrzeslanek[i];
                    najwieksza = i;
                }
            }
            //Console.WriteLine(najwieksza);
            //Console.WriteLine(sprawdz);
            //Console.WriteLine(PrzeKonList[najwieksza].nazwa);

            //List<PrzeslankiKonkluzje> PrzeKonList2 = new List<PrzeslankiKonkluzje>();
            //StringBuilder zmiennyUsuwanyWarunek = new StringBuilder("");
            string zmiennyUsuwanyWarunek0 = usuwanyWarunek;
            string zmiennyUsuwanyWarunek1 = usuwanyWarunek;
            string zmiennyUsuwanyWarunek2 = usuwanyWarunek;
            string zmiennyUsuwanyWarunek3 = usuwanyWarunek;
            int doOdrzucenia = PrzeKonList[najwieksza].grupa;
            
            //if (iloscGrup < -20)
            //{
            //    Console.WriteLine("test1");
            //    return;
            //}

            for (int licznikWierszy = 0; licznikWierszy < PrzeKonList.Count; licznikWierszy++)
            {
                if (PrzeKonList[licznikWierszy].grupa == doOdrzucenia)
                {
                    switch (PrzeKonList[licznikWierszy].indeksWGrupie)
                    {
                        case 0:
                            {
                                List<PrzeslankiKonkluzje> PrzeKonList1 = new List<PrzeslankiKonkluzje>();
                                for (int licznikNowychWierszy = 0; licznikNowychWierszy < PrzeKonList.Count; licznikNowychWierszy++)
                                {
                                    if (PrzeKonList[licznikNowychWierszy].grupa == doOdrzucenia)
                                    { }
                                    else
                                    {
                                        List<bool> elementy1 = new List<bool>();
                                        for (int licznikKolumn = 0; licznikKolumn < PrzeKonList[licznikWierszy].wartosci.Count; licznikKolumn++)
                                        {
                                            if (PrzeKonList[licznikWierszy].wartosci[licznikKolumn] == true)
                                            {
                                                elementy1.Add(PrzeKonList[licznikNowychWierszy].wartosci[licznikKolumn]);
                                            }
                                        }
                                        PrzeKonList1.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikNowychWierszy].nazwa, elementy1, PrzeKonList[licznikNowychWierszy].grupa, PrzeKonList[licznikNowychWierszy].indeksWGrupie));
                                    }
                                }
                                licznikRekurencji++;
                                iloscGrup--;
                                //zmiennyUsuwanyWarunek.Append(PrzeKonList[licznikWierszy].nazwa + " + ");
                                zmiennyUsuwanyWarunek0 += PrzeKonList[licznikWierszy].nazwa;
                                zmiennyUsuwanyWarunek0 += " + ";
                                Przelicz(PrzeKonList1, licznikRekurencji, iloscGrup, zmiennyUsuwanyWarunek0);
                                break;
                            }
                        case 1:
                            {
                                List<PrzeslankiKonkluzje> PrzeKonList1 = new List<PrzeslankiKonkluzje>();
                                for (int licznikNowychWierszy = 0; licznikNowychWierszy < PrzeKonList.Count; licznikNowychWierszy++)
                                {
                                    if (PrzeKonList[licznikNowychWierszy].grupa == doOdrzucenia)
                                    { }
                                    else
                                    {
                                        List<bool> elementy1 = new List<bool>();
                                        for (int licznikKolumn = 0; licznikKolumn < PrzeKonList[licznikWierszy].wartosci.Count; licznikKolumn++)
                                        {
                                            if (PrzeKonList[licznikWierszy].wartosci[licznikKolumn] == true)
                                            {
                                                elementy1.Add(PrzeKonList[licznikNowychWierszy].wartosci[licznikKolumn]);
                                            }
                                        }
                                        PrzeKonList1.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikNowychWierszy].nazwa, elementy1, PrzeKonList[licznikNowychWierszy].grupa, PrzeKonList[licznikNowychWierszy].indeksWGrupie));
                                    }
                                }
                                licznikRekurencji++;
                                iloscGrup--;
                                //zmiennyUsuwanyWarunek.Append(PrzeKonList[licznikWierszy].nazwa + " + ");
                                zmiennyUsuwanyWarunek1 += PrzeKonList[licznikWierszy].nazwa;
                                zmiennyUsuwanyWarunek1 += " + ";
                                Przelicz(PrzeKonList1, licznikRekurencji, iloscGrup, zmiennyUsuwanyWarunek1);
                                break;
                            }
                        case 2:
                            {
                                List<PrzeslankiKonkluzje> PrzeKonList1 = new List<PrzeslankiKonkluzje>();
                                for (int licznikNowychWierszy = 0; licznikNowychWierszy < PrzeKonList.Count; licznikNowychWierszy++)
                                {
                                    if (PrzeKonList[licznikNowychWierszy].grupa == doOdrzucenia)
                                    { }
                                    else
                                    {
                                        List<bool> elementy1 = new List<bool>();
                                        for (int licznikKolumn = 0; licznikKolumn < PrzeKonList[licznikWierszy].wartosci.Count; licznikKolumn++)
                                        {
                                            if (PrzeKonList[licznikWierszy].wartosci[licznikKolumn] == true)
                                            {
                                                elementy1.Add(PrzeKonList[licznikNowychWierszy].wartosci[licznikKolumn]);
                                            }
                                        }
                                        PrzeKonList1.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikNowychWierszy].nazwa, elementy1, PrzeKonList[licznikNowychWierszy].grupa, PrzeKonList[licznikNowychWierszy].indeksWGrupie));
                                    }
                                }
                                licznikRekurencji++;
                                iloscGrup--;
                                //zmiennyUsuwanyWarunek.Append(PrzeKonList[licznikWierszy].nazwa + " + ");
                                zmiennyUsuwanyWarunek2 += PrzeKonList[licznikWierszy].nazwa;
                                zmiennyUsuwanyWarunek2 += " + ";
                                Przelicz(PrzeKonList1, licznikRekurencji, iloscGrup, zmiennyUsuwanyWarunek2);
                                break;
                            }
                        case 3:
                            {
                                List<PrzeslankiKonkluzje> PrzeKonList1 = new List<PrzeslankiKonkluzje>();
                                for (int licznikNowychWierszy = 0; licznikNowychWierszy < PrzeKonList.Count; licznikNowychWierszy++)
                                {
                                    if (PrzeKonList[licznikNowychWierszy].grupa == doOdrzucenia)
                                    { }
                                    else
                                    {
                                        List<bool> elementy1 = new List<bool>();
                                        for (int licznikKolumn = 0; licznikKolumn < PrzeKonList[licznikWierszy].wartosci.Count; licznikKolumn++)
                                        {
                                            if (PrzeKonList[licznikWierszy].wartosci[licznikKolumn] == true)
                                            {
                                                elementy1.Add(PrzeKonList[licznikNowychWierszy].wartosci[licznikKolumn]);
                                            }
                                        }
                                        PrzeKonList1.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikNowychWierszy].nazwa, elementy1, PrzeKonList[licznikNowychWierszy].grupa, PrzeKonList[licznikNowychWierszy].indeksWGrupie));
                                    }
                                }
                                licznikRekurencji++;
                                iloscGrup--;
                                //zmiennyUsuwanyWarunek.Append(PrzeKonList[licznikWierszy].nazwa + " + ");
                                zmiennyUsuwanyWarunek3 += PrzeKonList[licznikWierszy].nazwa;
                                zmiennyUsuwanyWarunek3 += " + ";
                                Przelicz(PrzeKonList1, licznikRekurencji, iloscGrup, zmiennyUsuwanyWarunek3);
                                break;
                            }
                    }
                }
            }
            //    else
            //    {
            //        List<bool> elementy1 = new List<bool>();
            //        List<bool> elementy2 = new List<bool>();

            //        for (int licznikKolumn = 0; licznikKolumn < PrzeKonList[najwieksza].wartosci.Count; licznikKolumn++)
            //        {
            //            if (PrzeKonList[najwieksza].wartosci[licznikKolumn] == true)
            //            {
            //                elementy1.Add(PrzeKonList[licznikWierszy].wartosci[licznikKolumn]);
            //            }
            //            else
            //            {
            //                elementy2.Add(PrzeKonList[licznikWierszy].wartosci[licznikKolumn]);
            //            }
            //        }
            //        PrzeKonList1.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikWierszy].nazwa, elementy1, PrzeKonList[licznikWierszy].grupa));
            //        PrzeKonList2.Add(new PrzeslankiKonkluzje(PrzeKonList[licznikWierszy].nazwa, elementy2, PrzeKonList[licznikWierszy].grupa));
            //    }
            //}
            //licznikRekurencji++;
            //iloscGrup--;
            ////Console.WriteLine("licznik rekurencji: " + licznikRekurencji);
            ////Console.WriteLine("usuwany warunek: " + najwieksza);
            ////Console.WriteLine("drzewo: " + drzewo);
            ////Console.WriteLine("nazwa warunku: " + PrzeKonList1[najwieksza].nazwa);
            //usuwanyWarunek.Append(PrzeKonList[najwieksza].nazwa + " + ");
            //StringBuilder warunek = new StringBuilder("nic ");
            //ByleJak(PrzeKonList1, licznikRekurencji, iloscGrup, usuwanyWarunek);
            //ByleJak(PrzeKonList2, licznikRekurencji, iloscGrup, warunek );
        }
        static void Main(string[] args)
        {
            List<PrzeslankiKonkluzje> PrzeKonList = new List<PrzeslankiKonkluzje>();
            Console.WriteLine("Podaj sciezke - oczekiwany plik - sztuczna.csv"); 
            var sciezka = Console.ReadLine().TrimStart().TrimEnd();
            // wiersze = 0;
            using (var reader = new StreamReader(File.OpenRead(sciezka)))
            {
                //int jedna = 0;
                //int druga = 1;
                //int trzecia = 0;
                //int czwarta = 0;
                int indeksGrupy = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var wartosci = line.Split(';');
                    string nazwa;
                    string nazwaWarunku;
                    List<bool> elementy = new List<bool>();
                    bool rzut;
                    //nazwa = wartosci.ToList().RemoveAt(0);
                    var wartosci_lista = wartosci.ToList();
                    nazwa = wartosci_lista.First();
                    wartosci_lista.RemoveAt(0);
                    nazwaWarunku = wartosci_lista.First();
                    wartosci_lista.RemoveAt(0);
                    //Console.WriteLine(nazwa);
                    foreach (var war in wartosci_lista)
                    {
                        if(war.Contains("0")||war.Contains("1"))
                        {
                            rzut = TBoolean(war);
                            elementy.Add(rzut);
                            //Console.Write(rzut);
                        }
                        
                    }
                    if (nazwa.Length == 0)
                    {

                    }
                    else if (nazwaWarunku.Length == 0)
                    {

                    }
                    else
                    {
                        //if (trzecia < 3)
                        //{
                        //    if (jedna < 2)
                        //    {
                        //        PrzeKonList.Add(new PrzeslankiKonkluzje(nazwaWarunku, elementy, druga));
                        //        jedna++;
                        //    }
                        //    else
                        //    {
                        //        jedna = 0;
                        //        trzecia++;
                        //        PrzeKonList.Add(new PrzeslankiKonkluzje(nazwa, elementy, druga));
                        //        druga++;
                        //    }
                        //}
                        //else
                        //{
                        //    if (czwarta < 4)
                        //    {
                        //        PrzeKonList.Add(new PrzeslankiKonkluzje(nazwa, elementy, 4));
                        //        czwarta++;
                        //    }
                        //    else
                        //    {
                        //        PrzeKonList.Add(new PrzeslankiKonkluzje(nazwa, elementy, 5));
                        //    }
                        //}
                        if (nazwa.Contains("."))
                        {
                            PrzeKonList.Add(new PrzeslankiKonkluzje(nazwaWarunku, elementy, indeksGrupy));
                        }
                        else
                        {
                            indeksGrupy++;
                            PrzeKonList.Add(new PrzeslankiKonkluzje(nazwaWarunku, elementy, indeksGrupy));
                        }
                    }
                }
            }

            //Console.WriteLine(PrzeKonList.Count);

            //for (int i = PrzeKonList.Count - 3; i < PrzeKonList.Count; i++)
            //{
            //    Console.WriteLine(KonkluzjeLog(PrzeKonList[i]));
            //}
            //Console.WriteLine(FaktycznaEntropia(PrzeKonList[2], PrzeKonList));

            //Console.WriteLine(EntropiaKonkluzji(PrzeKonList));

            int licznikRekurencji = -1;
            //StringBuilder usuwanyWarunek = new StringBuilder("");
            Przelicz(PrzeKonList, licznikRekurencji, 5, "");
            Console.ReadKey();

        }
    }
}

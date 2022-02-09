using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SI_Projekt;

namespace SI_Test
{
    [TestClass]
    public class UnitTest
    {
        #region KoncowaEntropia
        [TestMethod]
        public void UnitTest_KoncowaEntropia_Expected()
        {
            double entropiaKonkluzji = 20;
            double entropiaPrzeslanki = 10;

            double expected = 10;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.KoncowaEntropia(entropiaKonkluzji, entropiaPrzeslanki);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_KoncowaEntropia_Expected1()
        {
            double entropiaKonkluzji = 20;
            double entropiaPrzeslanki = 10;

            double expected = 10;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.KoncowaEntropia(entropiaKonkluzji, entropiaPrzeslanki);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_KoncowaEntropia_Expecte2d()
        {
            double entropiaKonkluzji = 20;
            double entropiaPrzeslanki = 10;

            double expected = 10;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.KoncowaEntropia(entropiaKonkluzji, entropiaPrzeslanki);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_KoncowaEntropia_NegativeNumber()
        {
            double entropiaKonkluzji = 10;
            double entropiaPrzeslanki = 20;

            double expected = -10;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.KoncowaEntropia(entropiaKonkluzji, entropiaPrzeslanki);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TBoolean
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnitTest_TBoolean_Null()
        {
            string value = null;

            var testClass = new DrzewoDecyzyjne();

            bool actual = testClass.TBoolean(value);
        }

        [TestMethod]
        public void UnitTest_TBoolean_True()
        {
            string value = "1";
            bool expected = true;

            var testClass = new DrzewoDecyzyjne();

            bool actual = testClass.TBoolean(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitTest_TBoolean_False()
        {
            string value = "0";
            bool expected = false;

            var testClass = new DrzewoDecyzyjne();

            bool actual = testClass.TBoolean(value);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnitTest_TBoolean_Default()
        {
            string value = "50";
            var testClass = new DrzewoDecyzyjne();
            bool actual = testClass.TBoolean(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnitTest_TBoolean_Empty()
        {
            string value = "";
            var testClass = new DrzewoDecyzyjne();
            bool actual = testClass.TBoolean(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnitTest_TBoolean_Throw()
        {
            string value = "5";
            var testClass = new DrzewoDecyzyjne();
            bool actual = testClass.TBoolean(value);
        }
        #endregion

        #region FunkcjaLogarytmiczna
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected8()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected7()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected6()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected5()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected4()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected3()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected2()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Expected1()
        {
            int pozytywI = 20;
            int caloscI = 10;

            double expected = -2;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UnitTest_FunkcjaLogarytmiczna_Zero()
        {
            int pozytywI = -10;
            int caloscI = 20;

            double expected = 0;
            var testClass = new DrzewoDecyzyjne();

            double actual = testClass.FunkcjaLogarytmiczna(pozytywI, caloscI);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        /*
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

        public static double KoncowaEntropia(double entropiaKonkluzji, double entropiaPrzeslanki)
        {
            double wynik = entropiaKonkluzji - entropiaPrzeslanki;
            return wynik;
        }
        

         public bool TBoolean(string war)
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

        [TestMethod]
        public void Task1_IsZero()
        {
            // arrange
            int arg1 = 10;
            bool expected = true;
            var testClass = new Zajecia();

            // act
            bool actual = testClass.IsEven(arg1);

            // assert
            Assert.AreEqual(expected, actual);
        }
        */
    }
}

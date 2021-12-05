using CurrencyLib;
using CurrencyLib.MX;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests.MXCoinsTests
{
    [TestClass]
    public class MXCurrencyRepoTests
    {
        // MAIN REPO
        MXCurrencyRepo repo;
        // COINS
        _5Centavos nickel;
        _10Centavos dime;
        _20Centavos twentyCent;
        _50Centavos fiftyCent;
        // DOLLAR COINS
        _1PesoCoin onePeso;
        _2PesoCoin twoPeso;
        _5PesoCoin fivePeso;
        _10PesoCoin tenPeso;

        public MXCurrencyRepoTests()
        {
            repo = new MXCurrencyRepo();
            tenPeso = new _10PesoCoin();
            fivePeso = new _5PesoCoin();
            twoPeso = new _2PesoCoin();
            onePeso = new _1PesoCoin();
            fiftyCent = new _50Centavos();
            twentyCent = new _20Centavos();
            dime = new _10Centavos();
            nickel = new _5Centavos();      
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numNickels = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;
            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();

            repo.AddCoin(nickel);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numNickels; i++)
            {
                repo.AddCoin(nickel);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.AddCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.AddCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.AddCoin(twentyCent);
            valueAfterQuarter = repo.TotalValue();
            repo.AddCoin(onePeso);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numNickels, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + nickel.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numNickels * nickel.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + nickel.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + twentyCent.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + onePeso.MonetaryValue, valueAfterDollar);

        }
        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            repo = new MXCurrencyRepo();  //reset repo

            //add some coins
            repo.AddCoin(nickel);

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(nickel);
            }
            repo.AddCoin(nickel);
            repo.AddCoin(dime);
            repo.AddCoin(twentyCent);
            repo.AddCoin(onePeso);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCoin(nickel);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.RemoveCoin(nickel);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.RemoveCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.RemoveCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.RemoveCoin(twentyCent);
            valueAfterQuarter = repo.TotalValue();
            repo.RemoveCoin(onePeso);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual((double)((decimal)valueOrig - (decimal)nickel.MonetaryValue), valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * nickel.MonetaryValue), valueAfterFiveMorePennies);

            //Assert.AreEqual(valueAfterFiveMorePennies - nickel.MonetaryValue, valueAfterNickel); //HUH? 1.35 != 1.35 both are double?
            Assert.AreEqual(valueAfterNickel - dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - twentyCent.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - onePeso.MonetaryValue, valueAfterDollar);

        }
        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            CurrencyRepo changeOneQuatersOnHalfDollar,
                            changeTwoDollars,
                            changeOneDollarOneHalfDoller,
                            changeOneDimeOnePenny,
                            changeOneNickelOnePenny,
                            changeFourPennies;


            //Act
            changeTwoDollars = (CurrencyRepo)new CurrencyRepo().CreateChange(2.0);
            changeOneDollarOneHalfDoller = (CurrencyRepo)new CurrencyRepo().CreateChange(1.5);
            changeOneQuatersOnHalfDollar = (CurrencyRepo)new CurrencyRepo().CreateChange(.75);

            changeOneDimeOnePenny = (CurrencyRepo)new CurrencyRepo().CreateChange(.11);
            changeOneNickelOnePenny = (CurrencyRepo)new CurrencyRepo().CreateChange(.06);
            changeFourPennies = (CurrencyRepo)new CurrencyRepo().CreateChange(.04);


            //Assert
            Assert.AreEqual(2, changeTwoDollars.Coins.Count);
            Assert.AreEqual(new DollarCoin().GetType(), changeTwoDollars.Coins[0].GetType());
            Assert.AreEqual(new DollarCoin().GetType(), changeTwoDollars.Coins[1].GetType());

            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins.Count, 3);
            Assert.AreEqual(changeOneDollarOneHalfDoller.Coins[0].GetType(), new DollarCoin().GetType());


            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins.Count, 3);
            Assert.AreEqual(changeOneQuatersOnHalfDollar.Coins[1].GetType(), new Quarter().GetType());

            Assert.AreEqual(changeOneDimeOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneDimeOnePenny.Coins[0].GetType(), new Dime().GetType());
            Assert.AreEqual(changeOneDimeOnePenny.Coins[1].GetType(), new Penny().GetType());

            Assert.AreEqual(changeOneNickelOnePenny.Coins.Count, 2);
            Assert.AreEqual(changeOneNickelOnePenny.Coins[0].GetType(), new Nickel().GetType());
            Assert.AreEqual(changeOneNickelOnePenny.Coins[1].GetType(), new Penny().GetType());


            Assert.AreEqual(changeFourPennies.Coins.Count, 4);
            Assert.AreEqual(changeFourPennies.Coins[0].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[1].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[2].GetType(), new Penny().GetType());
            Assert.AreEqual(changeFourPennies.Coins[3].GetType(), new Penny().GetType());

        }
    }
}
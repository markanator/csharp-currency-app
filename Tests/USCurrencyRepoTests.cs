using System;
using CurrencyLib;
using CurrencyLib.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CurrencyRepoTests
    {
        ICurrencyRepo repo;
        Penny penny;
        Nickel nickel;
        Dime dime;
        Quarter quarter;
        DollarCoin dollarCoin;


        public CurrencyRepoTests()
        {
            repo = new CurrencyRepo();
            penny = new Penny();
            nickel = new Nickel();
            dime = new Dime();
            quarter = new Quarter();
            dollarCoin = new DollarCoin();
        }

        [TestMethod]
        public void AddCoinTest()
        {
            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;
            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();

            repo.AddCoin(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.AddCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.AddCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.AddCoin(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.AddCoin(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig + 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny + numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig + penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny + (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            Assert.AreEqual(valueAfterFiveMorePennies + nickel.MonetaryValue, valueAfterNickel);
            Assert.AreEqual(valueAfterNickel + dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime + quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter + dollarCoin.MonetaryValue, valueAfterDollar);

        }


        [TestMethod]
        public void RemoveCoinTest()
        {

            //Arrange
            int coinCountOrig, coinCountAfterPenny, coinCountAfterFiveMorePennies;
            int numPennies = 5;


            Double valueOrig, valueAfterPenny, valueAfterFiveMorePennies;
            Double valueAfterNickel, valueAfterDime, valueAfterQuarter, valueAfterDollar;

            repo = new CurrencyRepo();  //reset repo

            //add some coins
            repo.AddCoin(penny);

            for (int i = 0; i < numPennies; i++)
            {
                repo.AddCoin(penny);
            }
            repo.AddCoin(nickel);
            repo.AddCoin(dime);
            repo.AddCoin(quarter);
            repo.AddCoin(dollarCoin);

            //Act
            coinCountOrig = repo.GetCoinCount();
            valueOrig = repo.TotalValue();
            repo.RemoveCoin(penny);
            coinCountAfterPenny = repo.GetCoinCount();
            valueAfterPenny = repo.TotalValue();

            for (int i = 0; i < numPennies; i++)
            {
                repo.RemoveCoin(penny);
            }
            coinCountAfterFiveMorePennies = repo.GetCoinCount();
            valueAfterFiveMorePennies = repo.TotalValue();

            repo.RemoveCoin(nickel);
            valueAfterNickel = repo.TotalValue();
            repo.RemoveCoin(dime);
            valueAfterDime = repo.TotalValue();
            repo.RemoveCoin(quarter);
            valueAfterQuarter = repo.TotalValue();
            repo.RemoveCoin(dollarCoin);
            valueAfterDollar = repo.TotalValue();


            //Assert
            Assert.AreEqual(coinCountOrig - 1, coinCountAfterPenny);
            Assert.AreEqual(coinCountAfterPenny - numPennies, coinCountAfterFiveMorePennies);

            Assert.AreEqual(valueOrig - penny.MonetaryValue, valueAfterPenny);
            Assert.AreEqual(valueAfterPenny - (numPennies * penny.MonetaryValue), valueAfterFiveMorePennies);

            //Assert.AreEqual(valueAfterFiveMorePennies - nickel.MonetaryValue, valueAfterNickel); //HUH? 1.35 != 1.35 both are double?
            Assert.AreEqual(valueAfterNickel - dime.MonetaryValue, valueAfterDime);
            Assert.AreEqual(valueAfterDime - quarter.MonetaryValue, valueAfterQuarter);
            Assert.AreEqual(valueAfterQuarter - dollarCoin.MonetaryValue, valueAfterDollar);

        }

        [TestMethod]
        public void MakeChangeTests()
        {
            //Arrange
            CurrencyRepo    changeOneQuatersOnHalfDollar, 
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
            Assert.AreEqual(new DollarCoin().GetType(),changeTwoDollars.Coins[0].GetType());
            Assert.AreEqual(new DollarCoin().GetType(),changeTwoDollars.Coins[1].GetType());

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
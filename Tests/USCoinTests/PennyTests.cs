using CurrencyLibs;
using CurrencyLibs.US;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PennyTests
    {

        [TestMethod]
        public void PennyConstructor()
        {
            //Arrange
            Penny p;
            Penny philPenny;
            //Act 
            p = new Penny();
            philPenny = new Penny(USCoinMintMark.P);
            //Assert
            //D is the default mint mark
            //Current Year is default year

            Assert.AreEqual(USCoinMintMark.P, philPenny.MintMark);
        }

        [TestMethod]
        public void PennyMonetaryValue()
        {
            //Arrange
            Penny p;
            //Act 
            p = new Penny();
            //Assert
            Assert.AreEqual(.01, p.MonetaryValue);
        }

        //[TestMethod]
        //public void PennyAbout()
        //{
        //    //Arrange
        //    Penny p;
        //    //Act 
        //    p = new Penny();
        //    //Assert
        //    //About output "US Penny is from 2017. It is worth $0.01. It was made in Denver"
        //}
    }
}
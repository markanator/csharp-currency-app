using CurrencyLib.US;
using System;

namespace CurrencyLib
{
    public class Penny : USCoin
    {
        public Penny()
        {
            this.MonetaryValue = 0.01;
            this.Name = "Penny";
            this.Year = DateTime.Now.Year;
        }

        public Penny(USCoinMintMark cm)
        {
            this.MintMark = cm;
            this.MonetaryValue = 0.01;
            this.Name = "Penny";
            this.Year = DateTime.Now.Year;
        }
    }
}
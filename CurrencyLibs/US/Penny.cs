using CurrencyLibs.US;
using System;

namespace CurrencyLibs.US
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
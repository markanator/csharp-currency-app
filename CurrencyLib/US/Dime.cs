using CurrencyLib.US;

namespace CurrencyLib
{
    public class Dime : USCoin
    {
        public Dime()
        {
            this.MonetaryValue = 0.1;
            this.Name = "Dime";
        }

        public Dime(USCoinMintMark cm)
        {
            this.MintMark = cm;
            this.MonetaryValue = 0.1;
            this.Name = "Dime";
        }
    }
}
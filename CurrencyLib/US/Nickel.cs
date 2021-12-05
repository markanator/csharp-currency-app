using CurrencyLib.US;

namespace CurrencyLib
{
    public class Nickel : USCoin
    {
        public Nickel()
        {
            this.MonetaryValue = 0.05;
            this.Name = "Nickel";
        }

        public Nickel(USCoinMintMark cm)
        {
            this.MintMark = cm;
            this.MonetaryValue = 0.05;
            this.Name = "Nickel";
        }
    }
}
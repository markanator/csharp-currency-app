namespace CurrencyLib
{
    public class Quarter : USCoin
    {
        public Quarter()
        {
            this.MonetaryValue = 0.25;
            this.Name = "Quarter";
        }

        public Quarter(USCoinMintMark cm)
        {
            this.MintMark = cm;
            this.MonetaryValue = 0.25;
            this.Name = "Quarter";
        }
    }
}
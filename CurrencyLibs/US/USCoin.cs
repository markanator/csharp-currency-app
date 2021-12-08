using System;

namespace CurrencyLibs.US
{
    public abstract class USCoin : Coin
    {
        public USCoinMintMark MintMark { get; set; }

        public USCoin()
        {
            this.MintMark = USCoinMintMark.D;
            this.Year = DateTime.Now.Year;
        }

        public USCoin(string _name, USCoinMintMark _mintMark, double _val, int _year)
        {
            this.MintMark = _mintMark;
            this.MonetaryValue = _val;
            this.Year = _year;
            this.Name = _name;
            
        }

        public override string About()
        {
            string mintVal = "";
            switch (this.MintMark)
            {
                case USCoinMintMark.P:
                    mintVal = "Philadephia";
                    break;
                case USCoinMintMark.S:
                    mintVal = "San Francisco";
                    break;
                case USCoinMintMark.W:
                    mintVal = "West Point";
                    break;
                case USCoinMintMark.D:
                    mintVal = "Denver";
                    break;
                default:
                    mintVal = "Denver";
                    break;
            }

            return $"US {this.Name} is from {this.Year}. It is worth {this.MonetaryValue:C}. It was made in {mintVal}";
        }

        public static string GetMintNameFromMark(USCoinMintMark val)
        {
            switch (val)
            {
                case USCoinMintMark.P:
                    return "Philadephia";
                case USCoinMintMark.S:
                    return "San Francisco";
                case USCoinMintMark.W:
                    return "West Point";
                case USCoinMintMark.D:
                    return "Denver";
                default:
                    return "Denver";
            }
        }
    }
}
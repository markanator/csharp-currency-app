using CurrencyLibs.Interfaces;

namespace CurrencyLibs
{
    public abstract class Coin : ICoin
    {
        public double MonetaryValue { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public Coin() { }

        public virtual string About()
        {
            return $"US {this.Name} is from {this.Year}. It is worth ${this.MonetaryValue:C}.";
        }
    }
}
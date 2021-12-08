namespace CurrencyLibs.Interfaces
{
    public interface ICurrency
    {
        public double MonetaryValue { get; }
        public string Name { get; }

        public string About()
        {
            return $"{this.Name}. It is worth {this.MonetaryValue}";
        }
    }
}
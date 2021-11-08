namespace CurrencyLib.Interfaces
{
    public interface IBankNote : ICurrency
    {
        public int Year { get; }
    }
}
using System.Collections.Generic;

namespace CurrencyLib.Interfaces
{
    public interface ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }
        public string About();
        public void AddCoin(ICoin c);
        public int GetCoinCount();
        public ICurrencyRepo MakeChange(double Amount);
        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost);
        public ICoin RemoveCoin(ICoin c);
        public double TotalValue();
    }
}
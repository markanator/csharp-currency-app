// using makeChane implementation from class demo
using CurrencyLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class MXCurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }
        public MXCurrencyRepo()
        {
            Coins = new List<ICoin>();
        }

        public string About()
        {
            return $"{this.ToString()}";
        }

        public void AddCoin(ICoin c)
        {
            if (c == null) throw new ArgumentNullException();
            this.Coins.Add(c);
        }
        public double TotalValue()
        {
            double totalval = 0;
            this.Coins.ForEach(coin => totalval += coin.MonetaryValue);
            return totalval;
        }
        public int GetCoinCount()
        {
            int totalCoins = 0;
            this.Coins.ForEach(coin => totalCoins += 1);
            return totalCoins;
        }
        private List<ICurrency> getCurrencyList()
        {
            List<ICurrency> list = new List<ICurrency>()
            {
                new _10PesoCoin(),
                new _5PesoCoin(),
                new _2PesoCoin(),
                new _1PesoCoin(),
                new _50Centavos(),
                new _20Centavos(),
                new _10Centavos(),
                new _5Centavos(),
            };

            return list.OrderByDescending(c => c.MonetaryValue).ToList();
        }
        public ICurrencyRepo MakeChange(double Amount)
        {
            return MakeChange(Amount, 0);
        }
        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            MXCurrencyRepo _change = new MXCurrencyRepo();
            Decimal Change = (Decimal)AmountTendered - (Decimal)TotalCost;

            List<ICurrency> currencyList = getCurrencyList();
            foreach (MXCoin c in currencyList)
            {
                while (Change >= (Decimal)c.MonetaryValue)
                {
                    _change.AddCoin(c);
                    Change -= (Decimal)c.MonetaryValue;
                }
            }
            return _change;
        }
        public ICoin RemoveCoin(ICoin c)
        {
            if (c == null) throw new ArgumentNullException();
            bool didRemove = this.Coins.Remove(c);

            return didRemove ? c : null;
        }
    }
}

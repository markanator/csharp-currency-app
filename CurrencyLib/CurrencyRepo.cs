using System;
using System.Collections.Generic;
using CurrencyLib.Interfaces;
using CurrencyLib.US;


namespace CurrencyLib
{
    public class CurrencyRepo : ICurrencyRepo
    {
        public List<ICoin> Coins { get; set; }
        public CurrencyRepo()
        {
            this.Coins = new List<ICoin>();
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
        public ICurrencyRepo CreateChange(double Amount)
        {
            CurrencyRepo retCurrencyRepo = new CurrencyRepo();
            // for every whole number we return a dollarCoin
            if (Amount >= 1.0)
            {
                int times = (int)Amount / (int)1.0;
                InsertInto(new DollarCoin(), times, retCurrencyRepo);
                Amount -= times;
            }
            // for every .25, we return quarter
            if (Amount >= 0.25)
            {
                int times = (int) (Amount / .25);
                InsertInto(new Quarter(), times, retCurrencyRepo);
                Amount -= (times * .25);
            }
            // for every .10, we return dime
            if (Amount >= 0.10)
            {
                int times = (int)Math.Floor(Amount / .10);
                InsertInto(new Dime(), times, retCurrencyRepo);
                Amount = RemoveFrom((decimal)Amount, times, 0.10m);
            }
            // for every .05, we return a dime
            if (Amount >= 0.05)
            {
                int times = (int)Math.Floor(Amount / .05);
                InsertInto(new Nickel(), times, retCurrencyRepo);
                Amount = RemoveFrom((decimal)Amount, times, 0.05m);
            }
            // for everything else we return a penny
            if (Amount >= 0.01)
            {
                int times = (int)Math.Floor(Amount / .01);
                InsertInto(new Penny(), times, retCurrencyRepo);
                Amount = RemoveFrom((decimal)Amount, times, 0.01m);
            }
            return retCurrencyRepo;
        }

        private void InsertInto(USCoin coin, int times, ICurrencyRepo repo)
        {
            for (int i = 0; i < times; i++)
            {
                repo.Coins.Add(coin);
            }
        }

        private double RemoveFrom(decimal src, int times, decimal toRemove)
        {
            for (int i = 0; i < times; i++)
            {
                src -= toRemove;
            }

            return (double)src;
        }
        
        public ICurrencyRepo CreateChange(double AmountTendered, double TotalCost)
        {
            throw new NotImplementedException();
        }
        public int GetCoinCount()
        {
            int totalCoins = 0;
            this.Coins.ForEach(coin => totalCoins += 1);
            return totalCoins;
        }
        public ICurrencyRepo MakeChange(double Amount)
        {
            throw new System.NotImplementedException();
        }
        public ICurrencyRepo MakeChange(double AmountTendered, double TotalCost)
        {
            throw new System.NotImplementedException();
        }
        public ICoin RemoveCoin(ICoin c)
        {
            if (c == null) throw new ArgumentNullException();
            bool didRemove = this.Coins.Remove(c);

            return didRemove ? c : null;
        }
        public double TotalValue()
        {
            double totalval = 0.0;
            this.Coins.ForEach(coin => totalval += coin.MonetaryValue);
            return totalval;
        }
    }
}
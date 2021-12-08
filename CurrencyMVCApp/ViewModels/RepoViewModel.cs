using CurrencyLib.Interfaces;
using System.Collections.Generic;

namespace CurrencyMVCApp.ViewModels
{
    public class RepoViewModel
    {
        ICurrencyRepo repo;
        public RepoViewModel(ICurrencyRepo repo)
        {
            this.repo = repo;
        }

        public double TotalValue
        {
            get { return repo.TotalValue(); }
        }

        public void MakeChange(double Amount)
        {
            repo = repo.MakeChange(Amount);
        }

        public List<ICoin> Coins
        {
            get { return repo.Coins; }
        }
    }
}

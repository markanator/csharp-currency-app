using CurrencyLibs.Interfaces;
using System.Collections.Generic;

namespace CurrencyMVCApp.ViewModels
{
    public class RepoViewModel
    {
        public ICurrencyRepo repo;
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
            var newRepo = repo.MakeChange(Amount);
            this.repo.Coins = newRepo.Coins;
        }

        public List<ICoin> Coins
        {
            get { return repo.Coins; }
        }
    }
}

using CurrencyLibs.Interfaces;
using System.Collections.Generic;

namespace CurrencyMVCApp.ViewModels
{
    public class RepoViewModel
    {
        public ICurrencyRepo repo { get; protected set; }
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

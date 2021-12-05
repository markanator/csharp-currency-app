using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public abstract class MXCoin : Coin
    {
        public MXCoin()
        {
            this.Year = DateTime.Now.Year;
        }

        public MXCoin(string _name, double _val, int _year)
        {
            this.Name = _name;
            this.MonetaryValue = _val;
            this.Year = _year;
        }

        public override string About()
        {
            return $"MX {this.Name} is from {this.Year}. It is worth {this.MonetaryValue:C}.";
        }
    }
}

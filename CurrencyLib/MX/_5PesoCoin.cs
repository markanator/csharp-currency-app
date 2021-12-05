using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class _5PesoCoin : MXCoin
    {
        public _5PesoCoin()
        {
            this.MonetaryValue = 5.00;
            this.Name = "5 Peso";
        }
    }
}

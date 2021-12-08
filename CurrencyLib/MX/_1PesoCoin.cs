using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class _1PesoCoin : MXCoin
    {
        public _1PesoCoin()
        {
            this.MonetaryValue = 1.00;
            this.Name = "$1 Peso";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class _10PesoCoin : MXCoin
    {
        public _10PesoCoin()
        {
            this.MonetaryValue = 10.00;
            this.Name = "$10 Pesos";
        }
    }
}

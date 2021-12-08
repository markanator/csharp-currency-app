using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibs.MX
{
    public class _2PesoCoin : MXCoin
    {
        public _2PesoCoin()
        {
            this.MonetaryValue = 2.00;
            this.Name = "$2 Peso";
        }
    }
}

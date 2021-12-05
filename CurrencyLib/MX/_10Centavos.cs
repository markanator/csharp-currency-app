using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class _10Centavos : MXCoin
    {
        public _10Centavos()
        {
            this.MonetaryValue = 0.10;
            this.Name = "10¢ Centavos";
        }
    }
}

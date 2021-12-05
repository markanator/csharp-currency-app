using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLib.MX
{
    public class _50Centavos : MXCoin
    {
        public _50Centavos()
        {
            this.MonetaryValue = 0.50;
            this.Name = "50¢ Centavos";
        }
    }
}

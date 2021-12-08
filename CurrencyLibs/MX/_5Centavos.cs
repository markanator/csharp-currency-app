using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyLibs.MX
{
    public class _5Centavos : MXCoin
    {
        public _5Centavos()
        {
            this.MonetaryValue = 0.05;
            this.Name = "5¢ Centavos";
        }
    }
}

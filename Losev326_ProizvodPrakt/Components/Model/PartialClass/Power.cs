using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Losev326_ProizvodPrakt.Components.Model
{
    public partial class Power
    {
        public string Color
        {
            get
            {
                if (IsDelete == true)
                    return "#FFA20000";
                else
                    return "Transparent";
            }
        }
    }
}

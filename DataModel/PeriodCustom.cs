using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public partial class Period
    {
        public override string ToString()
        {
            return String.Format("{0:d/MM/yyyy}-{1:d/MM/yyyy}", DateFrom, DateTo);
        }
    }
}

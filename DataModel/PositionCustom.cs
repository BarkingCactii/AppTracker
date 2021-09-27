using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public partial class Position
    {
        public override string ToString()
        {
            return String.Format("{0}@{1}", Position1, Company);
        }
    }
}

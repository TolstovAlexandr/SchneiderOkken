using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okken
{
    public interface IColomn
    {
        int maxNumbOfUnit { get; set; }
        int realNumbOfUnit { get; set; }
        bool isFull { get; set; }
    }
}

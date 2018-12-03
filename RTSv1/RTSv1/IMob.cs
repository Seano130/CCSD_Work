using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RTSv1
{
    public interface IMob
    {
        Vector Vel { get; set; }
        Vector Acc { get; set; }
        Decision Mode { get; set; }
        int Speed { get; set; }
        int Attack { get; set; }
        int AC { get; set; }
        int HousingCost { get; set; }
        

        Decision Decide(List<ILocateable> whatICanSeeNow, List<ILocateable> map);
               

    }
}

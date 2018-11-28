using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities; 

namespace RTSv1
{
    public interface IResource : ILocateable
    {
        ResourceType Type { get; }
        double Rate { get; set; }
    }
}

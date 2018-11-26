using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RTSv1
{
    public struct Cost
    {
        public Dictionary<ResourceType, int> ResourceCosts;

        public Cost(bool flag)
        {
            ResourceCosts = new Dictionary<ResourceType, int>();
        }

        public void Add(ResourceType rt, int amount)
        {
            if(ResourceCosts.ContainsKey(rt))
            {
                ResourceCosts[rt] += amount;
            }
        }
    }
}

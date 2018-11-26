using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public enum BuildingType
    {
        House, Barracks, Fort, Church, Farm, Camp
    }

    public enum Decision
    {
        Attack, Defend, Gather, Move
    }

    public enum Direction
    {
        North, South, West, East
    }

    public enum ResourceType
    {

    }

    public struct Action
    {
        public Decimal Decision;
        public Vector Goal;
    }
}

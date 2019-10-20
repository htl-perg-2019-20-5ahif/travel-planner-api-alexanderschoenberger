using System;

namespace Travel_Planner
{
    public class Plan
    {
        public string City { get; set; }

        public LeaveArrive[] ToLinz { get; set; }

        public LeaveArrive[] FromLinz { get; set; }
    }
}

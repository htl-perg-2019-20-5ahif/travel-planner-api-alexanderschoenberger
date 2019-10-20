using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner
{
    public class PlanWithLeaveArrrive : LeaveArrive
    {
        public string FromCity { get; set; }
        public string ToCity { get; set; }
    }
}

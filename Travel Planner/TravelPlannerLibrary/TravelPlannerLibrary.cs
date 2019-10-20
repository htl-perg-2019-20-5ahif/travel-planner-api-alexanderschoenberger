using Travel_Planner;

namespace TravelPlannerLibrary
{
    public class TravelPlannerLibrary
    {

        public PlanWithLeaveArrrive FindRoute(string from, string to, string start, Plan[] plan)
        {
            if (to.Equals("Linz"))
            {
                return loopThroughPlan(from, to, start, plan);
            }
            else if (from.Equals("Linz"))
            {
                return loopThroughPlan(to, from, start, plan);
            }
            var toLinz = loopThroughPlan(from, "Linz", start, plan);
            var fromLinz = loopThroughPlan(to, "Linz", toLinz.Arrive, plan);
            if(toLinz == null || fromLinz == null)
            {
                return null;
            }
            return new PlanWithLeaveArrrive()
            {
                FromCity = from,
                ToCity = to,
                Leave = toLinz.Leave,
                Arrive = fromLinz.Arrive
            };
        }

        private PlanWithLeaveArrrive loopThroughPlan(string from, string to, string start, Plan[] plan)
        {
            foreach (Plan p in plan)
            {
                if (p.City.Equals(from))
                {
                    foreach (LeaveArrive la in p.ToLinz)
                    {
                        if (la.Leave.CompareTo(start) >= 0)
                        {
                            return new PlanWithLeaveArrrive()
                            {
                                FromCity = from,
                                ToCity = to,
                                Leave = la.Leave,
                                Arrive = la.Arrive
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}

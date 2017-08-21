using System;
using System.Linq;

namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public class Respondent : Employee
    {
        public bool TakeCall(Call call)
        {
            if (!base.TakeCall(call, EmployeeType.Respondent))
            {
                var manager = CallCenter.Employees.FirstOrDefault(x => x.IsFree && x.GetType() == typeof(Manager));
                if (manager == null)
                    throw new InvalidOperationException("There is no managers in the call center to take the call");
                return ((Manager)manager).TakeCall(call);
            }
            return true;
        }

        public Respondent(CallCenter callCenter) : base(callCenter)
        {

        }
    }
}
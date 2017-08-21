using System;
using System.Linq;

namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public class Manager : Employee
    {
        public bool TakeCall(Call call)
        {
            if (!base.TakeCall(call, EmployeeType.Manager))
            {
                var director = CallCenter.Employees.FirstOrDefault(x => x.IsFree && x.GetType() == typeof(Director));
                if(director == null)
                    throw new InvalidOperationException("There is no directors in the call center to take the call");
                return ((Director)director).TakeCall(call);
            }
            return true;
        }

        public Manager(CallCenter callCenter) : base(callCenter)
        {
        }
    }
}
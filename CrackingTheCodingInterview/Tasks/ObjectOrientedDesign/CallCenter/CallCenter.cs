using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public class CallCenter
    {
        public ICollection<Employee> Employees;
        public Queue<Call> queue = new Queue<Call>();
        public CallCenter()
        {
            Employees = new List<Employee>();
        }

        public bool Simulate(Call call)
        {
            queue.Enqueue(call);
            var currentCall = queue.Dequeue();

            var respondent = Employees.First(x => x.IsFree && x.GetType() == typeof(Respondent));
            if (respondent == null)
                throw new InvalidOperationException("There is no respondents in the call center to take the call");
            return ((Respondent)respondent).TakeCall(currentCall);
        }
    }
}
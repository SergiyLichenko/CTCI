using System.Text;
using System.Threading.Tasks;

namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public abstract class Employee
    {
        public bool IsFree { get; protected set; } = true;
        public CallCenter CallCenter { get; private set; }
        public Employee(CallCenter callCenter)
        {
            CallCenter = callCenter;
        }

        public bool TakeCall(Call call, EmployeeType employeeType)
        {
            if (call.EmployeeType == employeeType)
            {
                IsFree = false;
                call.IsTaken = true;
                IsFree = true;
                return true;
            }
            return false;
        }
    }
}


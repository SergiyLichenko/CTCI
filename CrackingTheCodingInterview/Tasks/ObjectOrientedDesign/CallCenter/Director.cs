namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public class Director : Employee
    {
        public bool TakeCall(Call call)
            => base.TakeCall(call, EmployeeType.Director);

        public Director(CallCenter callCenter) : base(callCenter)
        {
        }
    }
}
namespace Tasks.ObjectOrientedDesign.CallCenter
{
    public class Call
    {
        public EmployeeType EmployeeType { get; private set; }

        public Call(EmployeeType employeeType)
        {
            EmployeeType = employeeType;
        }

        public bool IsTaken { get; set; }
    }
}
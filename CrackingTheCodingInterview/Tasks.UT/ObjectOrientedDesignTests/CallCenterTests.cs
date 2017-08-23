using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Tasks.ObjectOrientedDesign.CallCenter;
using Xunit;

namespace Tasks.UT.ObjectOrientedDesignTests
{
    public  class CallCenterTests
    {
        [Fact]
        public void CallCenter_Should_Check_Employee_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));

            var call = new Call(EmployeeType.Respondent);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Check_Manager_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));

            var call = new Call(EmployeeType.Manager);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Check_Director_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));
            callCenter.Employees.Add(new Director(callCenter));

            var call = new Call(EmployeeType.Director);

            //act
            var result = callCenter.Simulate(call);

            //assert
            result.ShouldBeEquivalentTo(true);
            call.IsTaken.ShouldBeEquivalentTo(true);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Repondents_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();

            var call = new Call(EmployeeType.Respondent);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Manager_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            var call = new Call(EmployeeType.Manager);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }

        [Fact]
        public void CallCenter_Should_Throw_If_No_Director_To_Take_Call()
        {
            //arrange
            var callCenter = new CallCenter();
            callCenter.Employees.Add(new Respondent(callCenter));
            callCenter.Employees.Add(new Manager(callCenter));
            var call = new Call(EmployeeType.Director);

            //act
            Action act = () => callCenter.Simulate(call);

            //assert
            act.ShouldThrow<InvalidOperationException>();
            call.IsTaken.ShouldBeEquivalentTo(false);
        }
    }
}

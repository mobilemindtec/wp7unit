
using System;
using System.Collections.Generic;

namespace MobileMindWP7Unit.Unit
{

    internal class TestResult
    {

        public const String SuccessMessage = "test passed";
        public String ClassName { get; set; }
        public String MethodName { get; set; }
        public String TestMessage { get; set; }
        public long ExecutionTime { get; set; }
        public IList<String> Messages { get; set; }

        public TestResult()
        {
            this.Messages = new List<String>();
        }

        public TestResult(String className, String methodName, String testMessage, long executionTime)
            :this()
        {
            this.ClassName = className;
            this.MethodName = methodName;
            this.TestMessage = testMessage;
            this.ExecutionTime = executionTime;
        }

        public bool IsFailed()
        {
            return !this.TestMessage.Equals(TestResult.SuccessMessage);
        }
    }
}
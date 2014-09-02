using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;
using System.Text;

namespace MobileMindWP7Unit.Unit
{


    class TestRunner
    {
        private static Dictionary<Type, IList<TestResult>> testFails = new Dictionary<Type, IList<TestResult>>();

        public static void CleanResults()
        {
            testFails.Clear();
        }

        public static String PrintTestsResult()
        {

            var html = new StringBuilder("<html>");
            const string fileName = "TestResult.html";
            var isf = IsolatedStorageFile.GetUserStoreForApplication();
            var stream = new IsolatedStorageFileStream(fileName, FileMode.Create, FileAccess.Write, isf);            
            var writer = new StreamWriter(stream);


            html.Append("<head><title> Tests Results </title></head>");
            html.Append("<body>");
            html.Append("<h1><font color='green'><center>Tests Result</center></font></h1>").Append("<br/>");
            html.Append("<HR color='#FF4500'/>");

            foreach (var c in TestRunner.testFails)
            {
                html.Append("<center><span style='color:#0000CD; font-size:14px; font-weight:bold;'>")
                        .Append(c.Key.Name).Append("</span></center>");

                foreach (TestResult result in c.Value)
                {
                    html.Append("<span style='font-size:15px; color:").Append(result.IsFailed() ? "#FF0000" : "#228B22").Append("'>").
                            Append(result.MethodName).Append("</span></br>");

                    foreach (String msg in result.Messages)
                    {
                        html.Append("<span style='font-size:15px'><b>Message:</b> ").Append(msg).Append("</span></br>");
                    }

                    html.Append("<span style='font-size:12px; margin-top:5px'><b>Status:</b> ").Append(result.TestMessage).Append(
                            "</span>");
                    html.Append("<br/><span style='font-size:15px; margin-top:5px'><b> Time:</b> ").Append(result.ExecutionTime).Append(
                            "ms</span></br>");
                    html.Append("<center><HR color='#FFD700' style='width:150px'/></center>");
                }
                html.Append("<HR color='#FF4500'/>");
            }

            html.Append("</body>");
            html.Append("</html>");

            writer.WriteLine(html.ToString());
            writer.Flush();
            writer.Close();
            stream.Close();

            return fileName;
        }

        public static void Run(Type clazz)
        {

            IList<MethodInfo> testMethods = new List<MethodInfo>();
            MethodInfo[] methods = clazz.GetMethods();
            ITestBehavior testCase = null;

            String testMessage = null;
            

            try
            {
                testCase = (ITestBehavior)Activator.CreateInstance(clazz);
            }
            catch (Exception e)
            {
                throw new Exception("can't create instance of " + clazz.FullName);
            }

            foreach (var method in methods)
            {
                if (method.Name.StartsWith("Test"))
                {
                    testMethods.Add(method);
                }
            }

            try
            {
                testCase.SetUpClass();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message,e);
            }

            foreach (var testMethod in testMethods)
            {
                var sw = new Stopwatch();
                try
                {                    
                    testCase.ClearMessages();
                    sw.Start();
                    testCase.SetUp();
                    testMethod.Invoke(testCase, new object[] { });
                    testCase.TearDown();
                }
                catch (Exception e)
                {
                    testMessage = TreatException(e);
                }

                if (testMessage == null)
                {
                    testMessage = TestResult.SuccessMessage;
                }

                sw.Stop();

                var tr = new TestResult(clazz.Name, testMethod.Name, testMessage, sw.ElapsedMilliseconds);
                foreach (String msg in testCase.GetMessage())
                {
                    tr.Messages.Add(msg);
                }

                testCase.ClearMessages();

                if (TestRunner.testFails.ContainsKey(clazz))
                {
                    TestRunner.testFails[clazz].Add(tr);
                }
                else
                {
                    IList<TestResult> trs = new List<TestResult> { tr };
                    TestRunner.testFails.Add(clazz, trs);
                }

                testMessage = null;
            }

            try
            {
                testCase.TearDownClass();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

        }

        private static String TreatException(Exception e)
        {
            String testMessage = null;

            if (e.InnerException is TestException)
            {
                testMessage = e.InnerException.Message;
            }
            else if (e.InnerException != null)
            {
                testMessage = e.InnerException.GetType().Name + ":" + e.InnerException.Message + "<br/>";
                testMessage += e.InnerException.StackTrace + "<br/>";
            }
            else
            {
                if (e.InnerException != null)
                {
                    testMessage = e.InnerException.GetType().Name + ":" + (e.InnerException.Message ?? "NULL") + "<br/>";
                }
                else
                {
                    testMessage = e.GetType().Name + ": NULL <br/>";
                }
                testMessage = e.StackTrace;
            }

            return testMessage;
        }
    }
}
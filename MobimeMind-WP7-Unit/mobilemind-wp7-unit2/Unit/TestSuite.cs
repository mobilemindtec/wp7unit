using System;
using System.Collections.Generic;

namespace MobileMindWP7Unit.Unit
{

public class TestSuite {
   

    private static IList<Type> testsCase = new List<Type>();

    /**
     * Add Test Class
     * 
     * @param cls 
     */
    public static void AddTestCase<T>() where T : ITestBehavior{
        if (!testsCase.Contains(typeof(T))) {
            testsCase.Add(typeof(T));
        }
    }

    /**
     * Print results in HTML format
     * 
     * @param context
     * @return
     * @throws Exception 
     */
    public static String PrintTestsResults(){
        String testsResult = TestRunner.PrintTestsResult();
        TestRunner.CleanResults();
        return testsResult;
    }

    /**
     * Run unit tests
     * 
     */
    public static void RunTestSuite() {
        foreach (var c in testsCase) {
            try {
                TestRunner.Run(c);
            } catch (Exception e) {
                
            }
        }
    }
}
}
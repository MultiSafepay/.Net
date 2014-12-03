using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiSafepay.IntegrationTests
{
    [TestClass]
    public class Init
    {
        [AssemblyInitialize]
        public static void TestRun_Initialize(TestContext context)
        {
            Trace.WriteLine("-------  Test run started  -------");
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine("api: " + ConfigurationManager.AppSettings["MultiSafepayAPI"]);
            Trace.WriteLine("api_key: " + ConfigurationManager.AppSettings["MultiSafepayAPIKey"]);
            Trace.WriteLine(String.Empty);
        }

        [AssemblyCleanup]
        public static void TestRun_Cleanup()
        {
            Trace.WriteLine(String.Empty);
            Trace.WriteLine(DateTime.Now);
            Trace.WriteLine("------- Test run ended  -------");
            Trace.Flush();
        }
    }
}

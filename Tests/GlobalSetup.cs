using System;
using NUnit.Framework;


namespace PlaywrightTests.Tests
{
    [SetUpFixture]
    public class MySetUpClass
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            //  var baseUrl = TestContext.Parameters["apiUrl"] ?? "https://localhost:3000";
            TestContext.Progress.WriteLine("Global Setup: Initializing resources...");
        }


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            TestContext.Progress.WriteLine("Global Teardown: Cleaning up resources...");
        }
    }
}

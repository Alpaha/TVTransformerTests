using Atata;
using NUnit.Framework;

namespace TVTransformerTests
{
    [TestFixture]
    public class UITestFixture
    {
        [SetUp]
        public void SetUp()
        {
            // Find information about AtataContext set-up on https://atata.io/getting-started/#set-up
            AtataContext.Configure().
                UseChrome().
                WithArguments("start-maximized").
                UseBaseUrl("https://planeta.tc/").
                UseCulture("en-us").
                UseNUnitTestName().
                AddNUnitTestContextLogging().
                LogNUnitError().
                UseAssertionExceptionType<NUnit.Framework.AssertionException>().
                UseNUnitAggregateAssertionStrategy().
                Build();
        }

        [TearDown]
        public void TearDown()
        {
            AtataContext.Current?.CleanUp();
        }
    }
}

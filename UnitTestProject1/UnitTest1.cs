using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIKONSystem.Controllers;
using SIKONSystem.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        LecturesController LecturesController= new LecturesController();
        private MvcDbContext context = new MvcDbContext();

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

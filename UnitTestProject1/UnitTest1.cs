using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIKONSystem.Controllers;
using SIKONSystem.Data;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private MvcDbContext context;
        LecturesController LecturesController= new LecturesController(context);
        

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

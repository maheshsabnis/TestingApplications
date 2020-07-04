using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest_CS_SourceApp
{
    [TestClass]
    public class HelloWordTest
    {

        [TestMethod]
        public void HelloWorldTest()
        {
            const string Expeted = "Hello World";
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                CS_SourceProject.Program.Main();
                var result = sw.ToString();
                Assert.AreEqual(Expeted,result);
            }
        }
    }
}

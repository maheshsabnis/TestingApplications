﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using CS_SourceProject;
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
                var result = sw.ToString().Trim();
                Assert.AreEqual(Expeted,result);
            }
        }

        [TestMethod]
        public void AddTest()
        {
            // arrange
            int x = 90;
            int y = 90;

            int expected = 180;
            // act
            int actual = CS_SourceProject.Program.Add(x,y);

            // assert
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void CollectionAssertTestMethod()
        {
            List<string> lst1 = new List<string>();
            lst1.Add("Mahesh");
            lst1.Add("Sabnis");
            List<string> lst2 = new List<string>();
            lst2.Add("Mahesh");
            lst2.Add("Sabnis");
            CollectionAssert.AreEqual(lst1,lst2);
            CollectionAssert.AllItemsAreInstancesOfType(lst1, typeof(string), "Items are not Same");
            // check if both collection contains same elements
            CollectionAssert.AreEquivalent(lst1,lst2);
            CollectionAssert.Contains(lst1, "Mahesh");
        }

        [TestMethod]
        public void CollectionAllItemsAreUnique()
        {
            List<int> lst = new List<int>();
            lst.Add(10);
            lst.Add(20);
            lst.Add(30);
            lst.Add(0);
            // check if collection contains all items as unique items
            CollectionAssert.AllItemsAreUnique(lst);
        }

        [TestMethod]
        public void ReferenceEqualTestMethod()
        {
            String str1 = "Mahesh";
            String str2 = "Sabnis";
            Assert.ReferenceEquals(str1,str2);
        }

        [TestMethod]
        public void ReferenceEqualListTestMethod()
        {
            List<int> lst1 = new List<int>();
            List<string> lst2 = new List<string>();
            CollectionAssert.ReferenceEquals(lst1,lst2);
        }

        [TestMethod]
        public void AllItemsAreNotNullTestMethod()
        {
            List<string> lst = new List<string>();
            lst.Add("C");
            lst.Add("A");
            lst.Add("B");
            // check if all members of the list are NOT NULL
            CollectionAssert.AllItemsAreNotNull(lst);
        }

        [TestMethod]
        public void ExceptionTest()
        {
            var ex = Assert.ThrowsException<DivideByZeroException>(() =>
            CS_SourceProject.Program.Divide(4, 0));
            Assert.AreEqual("Denominator cannot be zero 0", ex.Message);
        }

        [DataTestMethod]
        [DataRow(10,20)]
        //[DataRow(-10, 20)]
        //[DataRow(10, -20)]
        public void AddTestData(int x,int y)
        {
            var res = CS_SourceProject.Program.Add(x, y);
            Assert.AreEqual(30, res);
        }

        [TestMethod]
        public void BooleanTest()
        {
            int x = -9;
            var actual = CS_SourceProject.Program.PositiveValue(x);
            Assert.IsFalse(actual, "Value is Negative");
        }

        [TestMethod]
        public void AddListDataVoidMethodTest()
        {
           
            string name = "Mahesh";
            CS_SourceProject.Program.AddListData(name);
            CollectionAssert.Contains(CS_SourceProject.Program.lstGlobal, name);
        }

        [TestMethod]
        public void EventTestMethod()
        {
            CS_SourceProject.Banking bank = new CS_SourceProject.Banking(20000);
            List<string> events = new List<string>();
            bank.OverBalance += delegate (int amount)
            {
                events.Add("OverBalance");
            };

            bank.Deposit(100000);
            Assert.AreEqual("OverBalance", events[0]);
            
        }

        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }


        // [TestMethod()]

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "E:\\Fujitsu\\TestingApplications\\MSTest_CS_SourceApp\\bin\\Debug\\data.csv", "data#csv", DataAccessMethod.Sequential), DeploymentItem("data.csv"), TestMethod]
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "E:\\Fujitsu\\TestingApplications\\MSTest_CS_SourceApp\\bin\\Debug\\data1.csv", "data1#csv", DataAccessMethod.Sequential), DeploymentItem("data1.csv"), TestMethod]
         

        //      [DataSource("System.Data.SqlClient",
        //"Server=Localhost;Database = AppDbApi;Integrated Security = SSPI",
        //"DataSource",
        //DataAccessMethod.Sequential)]
        public void AddDataSourceTest()
        {
            // arrange
            // Access the data
            int x = Convert.ToInt32(TestContext.DataRow["Num1"]);
            int y = Convert.ToInt32(TestContext.DataRow["Num2"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Result"]);
            // act
            int actual = CS_SourceProject.Program.Add(x, y);
            // assert
            Assert.AreEqual(expected, actual);
        }

    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;
using WCF_IOC.Application.Interfaces;
using WCF_IOC.Domain.Interfaces.Repository;
using WCF_IOC.Infra.Data.Repositories;
using WCF_IOC.Application.AppServices;
using WCF_IOC.Domain.Interfaces.Service;
using WCF_IOC.Domain.Services;

namespace WCF_IOC.Application.Test
{
    /// <summary>
    /// Summary description for EstadoCityTest
    /// </summary>
    [TestClass]
    public class EstadoCityTest
    {
        public EstadoCityTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetEstadosECitys()
        {
            var container = new Container(x =>
            {
                x.For<ICityAppService>().Use<CityAppService>();
                x.For<ICityRepository>().Use<CityRepository>();
                x.For<ICityService>().Use<CityService>();


                x.For<IProvinceAppService>().Use<ProvinceAppService>();
                x.For<IProvinceRepository>().Use<ProvinceRepository>();
                x.For<IProvinceService>().Use<ProvinceService>();
            });

            var obj = container.GetInstance<IProvinceAppService>();
            var result = obj.GetProvinces();

            var obj1 = container.GetInstance<ICityAppService>();
            var result1 = obj1.GetCities("São Paulo");

            Assert.IsTrue(result != null && result1 != null);
        }
    }
}


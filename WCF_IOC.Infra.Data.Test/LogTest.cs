using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WCF_IOC.Infra.CrossCutting.Common;
using Newtonsoft.Json;

namespace WCF_IOC.Infra.Data.Test
{
    /// <summary>
    /// Summary description for LogTest
    /// </summary>
    [TestClass]
    public class LogTest
    {
        public LogTest()
        {
            //
            // TODO: Add constructor logic here
            //
            Configuracoes.ConfigureLOGFactories();
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
        public void TestarLogInfo()
        {
            Functions.WriteLog(System.Diagnostics.TraceLevel.Info, "mensagem");
            Functions.WriteLog(System.Diagnostics.TraceLevel.Info, "{0}");
            Functions.WriteLog(System.Diagnostics.TraceLevel.Info, "mensagem", args: DateTime.Now);
        }

        [TestMethod]
        public void TestarLogWarning()
        {
            Functions.WriteLog(System.Diagnostics.TraceLevel.Warning, "mensagem");
            Functions.WriteLog(System.Diagnostics.TraceLevel.Warning, "mensagem", args: DateTime.Now);
        }

        [TestMethod]
        public void TestarLogException()
        {
            Functions.WriteLog(System.Diagnostics.TraceLevel.Error, "mensagem");
            Functions.WriteLog(System.Diagnostics.TraceLevel.Error, "mensagem", new Exception("excecao"), args: DateTime.Now);
        }
        
        [TestMethod]
        public void Serializacao()
        {
            var result  = JsonConvert.SerializeObject(DateTime.Now, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore });
            Assert.IsTrue(result != null && result.Length > 0);
        }


    }
}

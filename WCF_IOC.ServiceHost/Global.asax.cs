using System;
using System.Web;
using StructureMap;
using WCF_IOC.Infra.CrossCutting.Common;
using System.Diagnostics;

namespace WCF_IOC
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
           Configuracoes.ConfigureLOGFactories();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            Functions.WriteLog(System.Diagnostics.TraceLevel.Error, "ERROR", exception);
        }


        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
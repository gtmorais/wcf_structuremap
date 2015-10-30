using WCF_IOC.Infra.CrossCutting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCF_IOC.ServiceHost.App_Code
{
    public class Startup //non-http initialization
    {
        public static void AppInitialize()
        {
            Configuracoes.ConfigureLOGFactories();
        }
    }
}

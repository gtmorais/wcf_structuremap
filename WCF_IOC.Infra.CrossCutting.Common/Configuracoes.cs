using WCF_IOC.Infra.CrossCutting.Common.Logging;
using System.Configuration;

namespace WCF_IOC.Infra.CrossCutting.Common
{
    public static class Configuracoes
    {
        public static readonly string smtpServer = ConfigurationManager.AppSettings["smtpServer"];

        public static void ConfigureLOGFactories()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());
        }
    }
}

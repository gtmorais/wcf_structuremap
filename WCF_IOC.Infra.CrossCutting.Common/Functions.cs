using WCF_IOC.Infra.CrossCutting.Common.Logging;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WCF_IOC.Infra.CrossCutting.Common
{
    public class Functions
    {
        static string GetDescription(Type type)
        {
            var descriptions = (DescriptionAttribute[])
                type.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (descriptions.Length == 0)
            {
                return null;
            }
            return descriptions[0].Description;
        }

        public static void WriteLog(TraceLevel level, string mensagem = "", Exception ex = null, [CallerMemberName]string memberName = "", params object[] args)
        {
            Task.Run(() =>
            {
                string output = "";
                output = string.Format("{0} - {1}", memberName, mensagem);

                switch (level)
                {
                    case TraceLevel.Info:
                        LoggerFactory.CreateLog().Info(output, args);
                        break;
                    case TraceLevel.Warning:
                        LoggerFactory.CreateLog().Warning(output, args);
                        break;
                    case TraceLevel.Error:
                        if (ex != null)
                        {
                            output = string.Format("{0} - {1} - {2}", memberName, mensagem, ex.Message);
                            LoggerFactory.CreateLog().Error(output, ex, args);
                        }
                        else
                            LoggerFactory.CreateLog().Error(output, args);
                        break;
                    default:
                        LoggerFactory.CreateLog().Warning(output, args);
                        break;
                }
            });
        }

    }
}

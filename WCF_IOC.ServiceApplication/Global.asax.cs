using Cabesp.ServicosBenner.Services.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;


namespace Cabesp.ServicosBenner.ServiceApplication
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();

            //System.ServiceModel.Activation.WebServiceHostFactory
        }

        private void RegisterRoutes()
        {
            RouteTable.Routes.Add(new ServiceRoute("BeneficiarioService", new StructureMapWebServiceHostFactory(), typeof(ServicosBenner.Services.Servicos.BeneficiarioService)));
            RouteTable.Routes.Add(new ServiceRoute("PrestadorService", new StructureMapWebServiceHostFactory(), typeof(ServicosBenner.Services.Servicos.PrestadorService)));
            RouteTable.Routes.Add(new ServiceRoute("EstadoService", new StructureMapWebServiceHostFactory(), typeof(ServicosBenner.Services.Servicos.EstadoService)));
            RouteTable.Routes.Add(new ServiceRoute("MunicipioService", new StructureMapWebServiceHostFactory(), typeof(ServicosBenner.Services.Servicos.MunicipioService)));
            //System.ServiceModel.Activation.WebServiceHostFactory = new Cabesp.ServicosBenner.Services.Configuration.StructureMapWebServiceHostFactory();
        }
    }
}
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using StructureMap;
using WCF_IOC.Infra.CrossCutting.Common.Logging;

namespace WCF_IOC.Services.Configuration
{
    public class StructureMapWebServiceHost : WebServiceHost
    {
        public StructureMapWebServiceHost(object singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses)
        { }

        public StructureMapWebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        { }

        protected override void OnOpening()
        {
            Description.Behaviors.Add(new StructureMapServiceBehavior());
            base.OnOpening();
        }
    }

    public class StructureMapWebServiceHostFactory : WebServiceHostFactory
    {
        public StructureMapWebServiceHostFactory()
        {
            LoggerFactory.SetCurrent(new TraceSourceLogFactory());  
        }
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new StructureMapWebServiceHost(serviceType, baseAddresses);
        }
    }
}

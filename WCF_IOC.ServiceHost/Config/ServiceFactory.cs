using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using StructureMap;

namespace WCF_IOC.Config
{
    public class ServiceFactory : ServiceHostFactory
    {
        public ServiceFactory()
            : base()
        {
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new WCFServiceHost(serviceType, baseAddresses);
        }
    }

    public class WCFServiceHost : ServiceHost
    {
        public WCFServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new WCFInstanceProvider(serviceType));
            }
        }
    }

    public class WCFInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private Type _serviceType;
        public static IContainer _container;

        public WCFInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        #region IInstanceProvider Members

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            if (_container == null)
                _container = WCF_IOC.Infra.CrossCutting.IoC.IoC.Initialize();
            return _container.GetInstance(_serviceType);
            //ObjectFactory.GetInstance(_serviceType);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        #endregion

        #region IContractBehavior Members

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        #endregion
    }
}
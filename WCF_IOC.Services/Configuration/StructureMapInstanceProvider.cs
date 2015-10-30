using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Services.Configuration
{
    public class StructureMapInstanceProvider : IInstanceProvider
    {
        private Type _serviceType;
        private IContainer _container;

        public StructureMapInstanceProvider(Type serviceType)
        {
            //if (_container == null)
            //    CreateBehavior();
            this._serviceType = serviceType;
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            //if (_container == null)
            //    CreateBehavior();
            return _container.GetInstance(_serviceType);
            //return ObjectFactory.GetInstance(_serviceType);
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            //No cleanup required
        }

        public Type BehaviorType
        {
            get { return this.GetType(); }
        }

        protected object CreateBehavior()
        {
            //_container = WCF_IOC.Infra.CrossCutting.IoC.IoC.Initialize();
            return _container;

            //ObjectFactory.Initialize(cfg =>
            //{
            //    cfg.Scan(scan =>
            //    {
            //        scan.WithDefaultConventions();
            //    });
            //});
            //return this;
        }
    }
}

using WCF_IOC.Application.Interfaces;
using WCF_IOC.Domain.Entities;
using WCF_IOC.Infra.CrossCutting.Common;
using WCF_IOC.Services.Interfaces;
using Newtonsoft.Json;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Services.Servicos
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class CityService : ICityService
    {
        ICityAppService _appService;

        public CityService(ICityAppService appService)
        {
            _appService = appService;
        }

        public CityService()
        {
            IContainer container = WCF_IOC.Infra.CrossCutting.IoC.IoC.Initialize();
            _appService = container.GetInstance<ICityAppService>();
        }

        public IEnumerable<City> GetCitiesByProvince(string estado)
        {
            Functions.WriteLog(TraceLevel.Info, estado);
            var result = _appService.GetCities(estado);
            Functions.WriteLog(TraceLevel.Info, estado, args: result);
            return result;
        }
    }
}

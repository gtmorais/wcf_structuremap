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
    //[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ProvinceService : IProvinceService
    {
        IProvinceAppService _appService;

        public ProvinceService(IProvinceAppService appService)
        {
            _appService = appService;
        }

        public IEnumerable<Province> GetEstados()
        {
            Functions.WriteLog(TraceLevel.Info);
            var result = _appService.GetProvinces();
            Functions.WriteLog(TraceLevel.Info, args: result);
            return result;
        }
    }
}

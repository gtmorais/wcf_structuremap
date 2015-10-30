using WCF_IOC.Application.Interfaces;
using WCF_IOC.Domain.Entities;
using WCF_IOC.Domain.Interfaces.Service;
using WCF_IOC.Infra.CrossCutting.Common.Caching;
using System.Collections.Generic;

namespace WCF_IOC.Application.AppServices
{
    public class ProvinceAppService : IProvinceAppService
    {
         IProvinceService _service;

        public ProvinceAppService(IProvinceService provinceService)
        {
            _service = provinceService;
        }

        public IEnumerable<Province> GetProvinces()
        {
            if (CacheProvider.Exist("GetProvinces"))
                return (CacheProvider.Get("GetProvinces") as IEnumerable<Province>);
            var estados = _service.GetProvinces();
            CacheProvider.Set("GetProvinces", estados, 12000);
            return estados;
        }
    }
}

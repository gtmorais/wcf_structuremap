using WCF_IOC.Application.Interfaces;
using WCF_IOC.Domain.Entities;
using WCF_IOC.Domain.Interfaces.Service;
using WCF_IOC.Infra.CrossCutting.Common.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Application.AppServices
{
    public class CityAppService : ICityAppService
    { 
        ICityService _service;

        public CityAppService(ICityService cityService)
        {
            _service = cityService;
        }

        public IEnumerable<City> GetCities(string province)
        {
            if (CacheProvider.Exist("GetCities" + province))
                return (CacheProvider.Get("GetCities" + province) as IEnumerable<City>);

            var cities = _service.GetCities(province);
            CacheProvider.Set("GetCities" + province, cities, 12000);
            return cities;
        }
    }
}

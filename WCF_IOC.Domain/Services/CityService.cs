using WCF_IOC.Domain.Entities;
using WCF_IOC.Domain.Interfaces.Repository;
using WCF_IOC.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _repository;

        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<City> GetCities(string province)
        {
            return _repository.GetCities(province);
        }
    }
}

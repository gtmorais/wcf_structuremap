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
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _repository;

        public ProvinceService(IProvinceRepository prestadorRepository)
        {
            _repository = prestadorRepository;
        }

        public IEnumerable<Province> GetProvinces()
        {
            return _repository.GetProvinces();
        }
    }
}

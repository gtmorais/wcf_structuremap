using WCF_IOC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Services.Interfaces
{
    [ServiceContract]
    public interface ICityService
    {
        [OperationContract]
        IEnumerable<City> GetCitiesByProvince(string province);
    }
}

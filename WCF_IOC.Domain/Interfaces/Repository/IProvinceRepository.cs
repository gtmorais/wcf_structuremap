using WCF_IOC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Domain.Interfaces.Repository
{
    public interface IProvinceRepository : IDisposable
    {
        IEnumerable<Province> GetProvinces();
    }
}


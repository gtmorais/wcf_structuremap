using WCF_IOC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Application.Interfaces
{
    public interface IProvinceAppService
    {
        IEnumerable<Province> GetProvinces();
    }
}

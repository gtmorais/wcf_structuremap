using WCF_IOC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using WCF_IOC.Domain.Interfaces.Repository;
using WCF_IOC.Infra.CrossCutting.Common;
using System.Diagnostics;

namespace WCF_IOC.Infra.Data.Repositories
{
    public class ProvinceRepository : BaseReadOnlyRepository, IProvinceRepository
    {
        public IEnumerable<Province> GetProvinces()
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var estados = conn.Query<Province>("Select Name, Abbreviation from Province");
                    return estados;
                }
            }
            catch (Exception ex)
            {
                Functions.WriteLog(TraceLevel.Error, ex.Message, ex);
                return null;
            }
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

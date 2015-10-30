using WCF_IOC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using WCF_IOC.Domain.Interfaces.Repository;
using System.Diagnostics;
using WCF_IOC.Infra.CrossCutting.Common;

namespace WCF_IOC.Infra.Data.Repositories
{
    public class CityRepository :BaseReadOnlyRepository, ICityRepository
    {
        public IEnumerable<City> GetCities(string province)
        {
            try
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    var cities = conn.Query<City>(@" SELECT City.Name, ZIP, Province.Name as 'Province' FROM City INNER JOIN Province ON City.Province = Province.ID
                                                       WHERE Province.Name=@province ORDER BY City.Name", new { Province = province });
                    return cities;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Domain.Entities
{
    [DataContract]
    public class Province
    {
        //[DataMember]
        //public string ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Sigla { get; set; }
    }
}
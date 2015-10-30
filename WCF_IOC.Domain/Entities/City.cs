using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCF_IOC.Domain.Entities
{
    [DataContract]
    public class City
    {
        //public int ID { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string CEP { get; set; }
        [DataMember]
        public string Estado { get; set; }
    }
}

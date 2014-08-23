using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ToDo.WCFService.Contracts
{
    [DataContract]
    public class ToDo
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime CreateDate { get; set; }
        [DataMember]
        public DateTime DeadLine { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Priority { get; set; }
    }
}

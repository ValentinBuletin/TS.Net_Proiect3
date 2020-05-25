using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [DataContract(IsReference = true)]
    public class TagDTO
    {
        [DataMember]
        public int Tag_Id { get; set; }
        [DataMember]
        public string Tag_Name { get; set; }
    }
}

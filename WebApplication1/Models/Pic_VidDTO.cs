using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [DataContract(IsReference = true)]
    public class Pic_VidDTO
    {
        [DataMember]
        public int Unique_Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Full_Path { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public double Size { get; set; }
        [DataMember]
        public System.DateTime Date_Created { get; set; }
        [DataMember]
        public System.DateTime Date_Modified { get; set; }
        [DataMember]
        public List<string> Values { get; set; }
    }
}

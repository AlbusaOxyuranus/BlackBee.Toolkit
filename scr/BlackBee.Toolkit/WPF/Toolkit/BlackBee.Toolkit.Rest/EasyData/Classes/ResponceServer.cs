using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BlackBee.Toolkit.Rest.EasyData.Classes
{
    [DataContract]
    public class ResponceServer<T> where T:class 
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "total_record")]
        public int TotalRecord { get; set; }

        [DataMember(Name = "data")]
        public List<T> DataList { get; set; }
        public ResponceServer()
        {
            DataList=new List<T>();
        }
    }
}

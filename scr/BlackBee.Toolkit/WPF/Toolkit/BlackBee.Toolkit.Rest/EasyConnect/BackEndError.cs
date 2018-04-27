using System.Runtime.Serialization;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    [DataContract]
    public class BackEndError
    {
        [DataMember(Name = "errorCode")]
        public string Code { get; set; }

        [DataMember(Name = "errorDescription")]
        public string Description { get; set; }

        //Один случай когда приходит и сессия
        [DataMember(Name = "sessionId")]
        public string SessionId { get; set; }
    }
}

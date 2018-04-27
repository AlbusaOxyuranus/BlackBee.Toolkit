using System.Xml.Serialization;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    [XmlRoot]
    public class Message
    {
        [XmlElement("Rus")]
        public string Rus { get; set; }
    }

    [XmlType]
    public class Error
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Message")]
        public Message Message { get; set; }

        [XmlElement("ProcRetCode")]
        public string Code { get; set; }

        [XmlElement("ServerTime")]
        public string TimeStamp { get; set; }
    }
}

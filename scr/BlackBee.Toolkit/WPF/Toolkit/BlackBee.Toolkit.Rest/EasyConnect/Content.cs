using System.Collections.Generic;
using System.Text;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    public class Content : Dictionary<string, string>
    {
        public Content Headers { get; set; }

        public Encoding Encoding { get; set; }
    }
}

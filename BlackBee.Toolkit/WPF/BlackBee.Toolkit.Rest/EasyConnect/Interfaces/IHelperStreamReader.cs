using System.Text;
using System.Threading.Tasks;

namespace BlackBee.Toolkit.Rest.EasyConnect.Interfaces
{
    public interface IHelperStreamReader
    {
        T ReadObject<T>(string responce, Encoding encoding = null) where T : class;
        T ReadObjectXML<T>(byte [] bytes, Encoding encoding = null) where T : class;
        Task<T> ReadObjectAsync<T>(string responce, Encoding encoding = null) where T : class;
    }
}

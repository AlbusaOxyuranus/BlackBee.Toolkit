using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlackBee.Toolkit.Rest.EasyConnect.Interfaces
{
    /// <summary>
    /// Интерфейс для прокси классс который будет реализовывать в себе некие методы для работы с сервером
    /// </summary>
    public interface IProxy
    {
        IHelperStreamReader HelperStreamReader { get; }
        HttpClient HttpClient { get;}

        void CreateHandler(HttpMessageHandler handler);

        #region GET

        Task GetAsync(string uri, Encoding encoding = null);
        Task<TClass> GetAsync<TClass>(string uri) 
            where TClass : class;

        #endregion

        #region POST

        Task PostAsync(string uri, Content content, Encoding encoding = null, Content headers = null);
        Task<TClass> PostAsync<TClass>(string uri, Content content, Encoding encoding = null, Content headers = null) 
            where TClass : class;
        Task<TClass> PostAsync<TClass,TClass2>(string uri, TClass2 class2, Encoding encoding = null, Content headers = null)
           where TClass : class
           where TClass2 : class;

        Task<TClass> PostAsync<TClass>(string uri) 
            where TClass : class;

        #endregion

     
        //Task<TClass> PostAsync<TClass>(string uri, Encoding encoding, TClass list) where TClass : class;
        Task PostAsync<TClass>(string uri, TClass list,Encoding encoding) where TClass : class;
        
        Task Delete(string uri);
        //Task<TClass> PostAsync<TClass>(string uri, Encoding encoding, List<string> requestList) where TClass : class;

        Task<TClass> PostAsync<TClass, TClass2>(string uri, TClass2 requestList, Encoding encoding = null)
            where TClass : class
            where TClass2 : class;


        
    }
}

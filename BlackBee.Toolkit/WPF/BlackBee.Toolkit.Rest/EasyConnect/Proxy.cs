using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using BlackBee.Toolkit.Rest.EasyConnect.Interfaces;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    /// <summary>
    /// Класс прокси который позволяет осуществлять запросы на сервер
    /// </summary>
   
    public class Proxy: IProxy
    {
        public IHelperStreamReader HelperStreamReader { get; private set; }
        public HttpClient HttpClient {  get; private set; }

        public Proxy()
        {
            CreateHandler();
            HelperStreamReader =new HelperStreamReader();
        }

        private void CheckedErrors(string responce)
        {
            var backEndError = HelperStreamReader.ReadObject<BackEndError>(responce);

            if (backEndError != null && !string.IsNullOrEmpty(backEndError.Code) && !string.IsNullOrEmpty(backEndError.Description))
            {
                throw new ConnectionBackEndException(backEndError.Code, backEndError.Description, backEndError.SessionId);
            }
        }

        public void CreateHandler(HttpMessageHandler handler = null)
        {
            HttpClient = handler == null ? new HttpClient() { Timeout = new TimeSpan(0, 0, 60) } : new HttpClient(handler);
            //HttpClient.DefaultRequestHeaders.IfModifiedSince = DateTimeOffset.Now;
        }
        private async Task<TClass> GetObject<TClass>(HttpResponseMessage response, Encoding encoding = null) where TClass : class
        {
            

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());

            var stream = await response.Content.ReadAsStreamAsync();

            var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

#if DEBUG
            Debug.WriteLine(" Dev Windows Phone Log : >> Method ReadObject is stream = " + responce);
#endif

            CheckedErrors(responce);
                return HelperStreamReader.ReadObject<TClass>(responce);
        }

        #region  implementation IProxy 

        #region GET

        public async Task GetAsync(string uri, Encoding encoding = null)
        {

            Debug.WriteLine(" Dev Windows Phone Log : >> url =  "+ uri);
            var response = await HttpClient.GetAsync(uri);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());

            var stream = await response.Content.ReadAsStreamAsync();

            var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

#if DEBUG
            Debug.WriteLine(" Dev Windows Phone Log : >> Method ReadObject is stream = " + responce);
#endif

            CheckedErrors(responce);

        }

        
        public async Task<TClass> GetAsync<TClass>(string uri) where TClass : class
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            var response = await HttpClient.GetAsync(uri);
            var result = await GetObject<TClass>(response);

            return result;
        }


        #endregion

        #region  POST
        public async Task PostAsync(string uri, Content content, Encoding encoding = null, Content headers = null)
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            content = content ?? new Content();
            var encodedContent = new EncodedContent(content, encoding);
            await HttpClient.PostAsync(uri, encodedContent);
            
        }

        public async Task<TClass> PostAsync<TClass>(string uri, Content content, Encoding encoding = null, Content headers = null) where TClass:class 
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            content = content ?? new Content();
            var encodedContent = new EncodedContent(content, encoding);
            var response = await HttpClient.PostAsync(uri, encodedContent);
            return await GetObject<TClass>(response);
        }

        public async Task<TClass> PostAsync<TClass, TClass2>(string uri, TClass2 class2, Encoding encoding = null, Content headers = null) where TClass : class where TClass2 : class
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            //Create a Json Serializer for our type 
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(TClass2));

            // use the serializer to write the object to a MemoryStream 
            MemoryStream ms = new MemoryStream();
            jsonSer.WriteObject(ms, class2);
            ms.Position = 0;

            //use a Stream reader to construct the StringContent (Json) 
            StreamReader sr = new StreamReader(ms);
            StringContent theContent = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(uri, theContent);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());

            return await GetObject<TClass>(response);
        }

        public Task<TClass> PostAsync<TClass>(string uri) where TClass : class
        {
            throw new NotImplementedException();
        }

        public async Task PostAsync<TClass>(string uri, TClass list, Encoding encoding) where TClass : class
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            //Create a Json Serializer for our type 
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(TClass));

            // use the serializer to write the object to a MemoryStream 
            MemoryStream ms = new MemoryStream();
            jsonSer.WriteObject(ms, list);
            ms.Position = 0;

            //use a Stream reader to construct the StringContent (Json) 
            StreamReader sr = new StreamReader(ms);
            StringContent theContent = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(uri, theContent);

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(response.StatusCode.ToString());
        }


        //public async Task PostAsync<TClass>(string uri, Encoding encoding, TClass list) 
        //    where TClass : class
        //{
        //    Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

        //    //Create a Json Serializer for our type 
        //    DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(TClass));

        //    // use the serializer to write the object to a MemoryStream 
        //    MemoryStream ms = new MemoryStream();
        //    jsonSer.WriteObject(ms, list);
        //    ms.Position = 0;

        //    //use a Stream reader to construct the StringContent (Json) 
        //    StreamReader sr = new StreamReader(ms);
        //    StringContent theContent = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");

        //    var response = await HttpClient.PostAsync(uri, theContent);

        //    if (response.StatusCode != HttpStatusCode.OK)
        //        throw new HttpRequestException(response.StatusCode.ToString());

        //    //return await GetObject<TClass>(response);
        //}

        public async Task Delete(string uri)
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);

            await HttpClient.DeleteAsync(uri);
        }

        public async Task<TClass> PostAsync<TClass, TClass2>(string uri, TClass2 requestList, Encoding encoding)
            where TClass : class
            where TClass2 : class
        {
            Debug.WriteLine(" Dev Windows Phone Log : >> url =  " + uri);
            //Create a Json Serializer for our type 
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(TClass2));

            // use the serializer to write the object to a MemoryStream 
            MemoryStream ms = new MemoryStream();
            jsonSer.WriteObject(ms, requestList);
            ms.Position = 0;

            //use a Stream reader to construct the StringContent (Json) 
            StreamReader sr = new StreamReader(ms);
            StringContent theContent = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(uri, theContent);

            return await GetObject<TClass>(response);
        }

        #endregion

        #endregion
    }
}

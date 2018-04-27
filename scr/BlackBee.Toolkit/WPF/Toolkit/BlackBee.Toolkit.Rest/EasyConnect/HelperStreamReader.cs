using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BlackBee.Toolkit.Rest.EasyConnect.Interfaces;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    public class HelperStreamReader:IHelperStreamReader
    {

        #region  implementation IHelperStreamReader

        public T ReadObject<T>(string responce, Encoding encoding = null) where T : class
        {
            //var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

            if(encoding==null)
                encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(responce);
            using (var streamMemory = new MemoryStream(bytes))
            using (var reader = new StreamReader(streamMemory, Encoding.UTF8))
            {
                return Serializer.DeserializeDataContractRequest<T>(reader.ReadToEnd());
            }
        }

        public T ReadObjectXML<T>(byte[] bytes, Encoding encoding = null) where T : class
        {
            if (encoding == null)
                encoding = Encoding.UTF8;
            try
            {
                if (typeof (T).Name != typeof (Error).Name)
                {
                    using (Stream stream_Test = new MemoryStream(bytes))
                    using (var reader = new StreamReader(stream_Test, Encoding.UTF8))
                    {
                        Debug.WriteLine("out xml = \r\n");
                        Debug.WriteLine(reader.ReadToEnd());
                    }
                }
                using (var streamMemory = new MemoryStream(bytes))
                using (var reader = new StreamReader(streamMemory, Encoding.UTF8))
                {
                    return new XmlSerializer(typeof (T)).Deserialize(reader) as T;
                }

            }
            catch (InvalidOperationException exception)
            {
                if (typeof (T).Name == typeof(Error).Name)
                {
#if DEBUG
                   
                    Debug.WriteLine(" Dev Windows Phone Log : >> method  no error ReadObjectXML and return null ");
                    using (Stream stream_Test = new MemoryStream(bytes))
                    using (var reader = new StreamReader(stream_Test, Encoding.UTF8))
                    {
                        Debug.WriteLine("out xml = \r\n");
                        Debug.WriteLine(reader.ReadToEnd());
                    }

#endif
                    return null;
                }
                else
                {
                    throw new Exception(exception.Message);
                }
            }

        
        }

        public async Task<T> ReadObjectAsync<T>(string responce, Encoding encoding = null) where T : class
        {
            //var responce = new StreamReader(stream, encoding ?? Encoding.UTF8).ReadToEnd();

            if (encoding == null)
                encoding = Encoding.UTF8;

            var bytes = encoding.GetBytes(responce);
            using (var streamMemory = new MemoryStream(bytes))
            using (var reader = new StreamReader(streamMemory, Encoding.UTF8))
            {
                return await Serializer.DeserializeDataContractRequestAsync<T>(reader.ReadToEnd());
            }
        }

        #endregion

    }
}

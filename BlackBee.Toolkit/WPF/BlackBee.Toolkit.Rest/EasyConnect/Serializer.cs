using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    public static class Serializer
    {
        public static readonly List<Type> KnownTypes = new List<Type>
        {
            typeof (Type),
            typeof (Dictionary<string, string>),
            typeof (List<Type>)
        };

        public static TItem DeserializeDataContractRequest<TItem>(string json)
        {
            //Dictionary<string, object> dictionary = new Dictionary<string, object>();
            try
            {
                if (!string.IsNullOrEmpty(json))
                {
                    var serializer = new DataContractJsonSerializer(typeof(TItem), KnownTypes);
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                    {
                        //var currentCulture = Thread.CurrentThread.CurrentCulture;
                        //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                        var item = serializer.ReadObject(stream);
                        //Thread.CurrentThread.CurrentCulture = currentCulture;
                        return (TItem)item;
                    }
                }
                return default(TItem);
            }
            catch (Exception exception)
            {
                return default(TItem);
            }
        }

        public static Task<TItem> DeserializeDataContractRequestAsync<TItem>(string json)
        {
            return Task.Run(() =>
            {
                //Dictionary<string, object> dictionary = new Dictionary<string, object>();
                try
                {
                    if (!string.IsNullOrEmpty(json))
                    {
                        var serializer = new DataContractJsonSerializer(typeof (TItem), KnownTypes);
                        using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                        {
                            //var currentCulture = Thread.CurrentThread.CurrentCulture;
                            //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                            var item = serializer.ReadObject(stream);
                            //Thread.CurrentThread.CurrentCulture = currentCulture;
                            return (TItem) item;
                        }
                    }
                    return default(TItem);
                }
                catch (Exception exception)
                {
                    return default(TItem);
                }
            });
        }


        public static TItem[] DeserializeDataArrayContractRequest<TItem>(string json)
        {
            try
            {
                if (!string.IsNullOrEmpty(json))
                {

                    var serializer = new DataContractJsonSerializer(typeof(TItem[]));
                    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
                    {
                        //var currentCulture = Thread.CurrentThread.CurrentCulture;
                        //Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                        TItem[] item = (TItem[])serializer.ReadObject(stream);
                        //Thread.CurrentThread.CurrentCulture = currentCulture;
                        return item;
                    }
                }
                return default(TItem[]);
            }
            catch (Exception exception)
            {
                return default(TItem[]);
            }
        }

        public static string SerializeToXmlString<TItem>(TItem item)
        {
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings { Indent = false, OmitXmlDeclaration = true };

            using (var output = new StringWriter())
            using (var writer = XmlWriter.Create(output, settings))
            {
                var serializer = new XmlSerializer(typeof(TItem));
                serializer.Serialize(writer, item, namespaces);
                var result = output.ToString();
                return result;
            }
        }

    }
}

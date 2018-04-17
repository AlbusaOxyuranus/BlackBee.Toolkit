using System;
using System.Text;
using BlackBee.Toolkit.Rest.EasyConnect;
using BlackBee.Toolkit.Rest.EasyConnect.Interfaces;

namespace BlackBee.Toolkit.Rest.EasyData
{
    public class DataContext:IDataContext
    {
        public DataContext(string nameConnnect, string baseAddress, Encoding encoding)
        {
            NameConnect = nameConnnect;

            if (encoding == null)
                encoding = Encoding.UTF8;

            BaseAddress = baseAddress;
            Proxy = new Proxy();
            Encoding = encoding;

           
        }
        

        public string BaseAddress { get; }
        public IProxy Proxy { get; protected set; }
        public Encoding Encoding { get; protected set; }

        #region   implementation IDisposable

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        public string NameConnect { get; set; }

        private void CheckedErrorsXml(byte[] buf)
        {
            var backEndError = new HelperStreamReader().ReadObjectXML<Error>(buf);

            if (backEndError != null && !string.IsNullOrEmpty(backEndError.Code) && !string.IsNullOrEmpty(backEndError.Message.Rus))
            {
                throw new ConnectionBackEndException(backEndError.Code, backEndError.Message.Rus, null);
            }
        } 
    }
}

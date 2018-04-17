using System;

namespace BlackBee.Toolkit.Rest.EasyData
{
    public interface IDataContext: IDisposable
    {
        string NameConnect { get; set; }
    }
}

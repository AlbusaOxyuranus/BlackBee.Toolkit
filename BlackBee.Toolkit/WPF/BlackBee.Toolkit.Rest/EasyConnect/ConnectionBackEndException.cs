using System;

namespace BlackBee.Toolkit.Rest.EasyConnect
{
    /// <summary>
    /// Ошибка которая формируется стороной сервера
    /// </summary>
    public class ConnectionBackEndException:Exception
    {
        /// <summary>
        /// Позволяет передавать нам все нужные параметры и соообщения от БЭКА
        /// </summary>
        /// <param name="errorCode" ><see cref="ErrorCode"/></param>
        /// <param name="errorMessage">Сообщение ошибки</param>
        ///  /// <param name="sessionId">Номер сессии</param>
        public ConnectionBackEndException(string errorCode, string errorMessage, string sessionId) : base(errorMessage)
        {
            ErrorCode = errorCode;
            SessionID = sessionId;
        }

        /// <summary>
        /// Код ошибки
        /// </summary>
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Уникальный номер сессии
        /// </summary>
        public string SessionID { get; set; }
    }
}

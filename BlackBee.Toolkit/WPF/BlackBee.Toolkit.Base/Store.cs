using System;
using System.Collections.Generic;

namespace BlackBee.Toolkit.Base
{
    /// <summary>
    ///     Класс хранилище формируется чтобы сохранять состояния
    /// </summary>
    public static class Store
    {
        /// <summary>
        /// Тут храяться все объекты которые учавствуют в работе
        /// </summary>
        private static readonly Dictionary<Type, object> StoreItemsDictionary;
        static Store()
        {
            StoreItemsDictionary = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Создать объект в коллекциии хранилища или вернуть уже существующий
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public static TClass CreateOrGet<TClass>(params object[] args) where TClass : class
        {
            var typeClass = typeof(TClass);
            if (StoreItemsDictionary.ContainsKey(typeClass))
            {
                return (TClass)StoreItemsDictionary[typeClass];
            }
            var itemClass = (TClass)Activator.CreateInstance(typeClass, args);
            StoreItemsDictionary.Add(typeClass, itemClass);
            return (TClass)StoreItemsDictionary[typeClass];
        }


        //internal static async Task SaveState()
        //{
        //    await Task.Delay(100);
        //    StoreItemsDictionary
        //        .Where(p => Attribute.IsDefined(p.Key, typeof(DataContractAttribute)))
        //        .Select(p => p.Value).ToList()
        //        .ForEach(i => i.SerializeDataContract());
        //}
    }
}
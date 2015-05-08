using System.Web.Mvc;

namespace MVCWeb.UI
{
    public static class ServerMessages
    {
        private enum Type
        {
            Message,
            Error
        }

        public static void SetMessage(TempDataDictionary data, string message)
        {
            Set(Type.Message, data, message);
        }

        public static string GetMessage(TempDataDictionary data)
        {
            return Get(Type.Message, data);
        }

        public static void SetError(TempDataDictionary data, string message)
        {
            Set(Type.Error, data, message);
        }

        public static string GetError(TempDataDictionary data)
        {
            return Get(Type.Error, data);
        }

        private static void Set(Type type, TempDataDictionary tempDataDictionary, string message)
        {
            if (string.IsNullOrEmpty(message) || tempDataDictionary.ContainsKey(type.ToString()))
            {
                return;
            }

            tempDataDictionary.Add(type.ToString(), message);
        }

        private static string Get(Type type, TempDataDictionary tempDataDictionary)
        {
            if (!tempDataDictionary.ContainsKey(type.ToString()))
            {
                return string.Empty;
            }

            return tempDataDictionary[type.ToString()].ToString();
        }
    }
}
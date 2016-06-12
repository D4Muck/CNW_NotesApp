using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;

namespace NotesApp.Service
{
    public class LocalStorageService
    {
        private static readonly ApplicationDataContainer AppData = ApplicationData.Current.LocalSettings;

        public static void Write<T>(string key, T value)
        {
            var json = JsonConvert.SerializeObject(value);
            AppData.Values[key] = json;
        }

        public static T Read<T>(string key)
        {
            return Read<T>(key, default(T));
        }

        public static T Read<T>(string key, T defaultValue)
        {
            if (!AppData.Values.ContainsKey(key))
            {
                return defaultValue;
            }
            var json = (string) AppData.Values[key];
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
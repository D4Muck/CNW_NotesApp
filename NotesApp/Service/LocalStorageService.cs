using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Streaming.Adaptive;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Newtonsoft.Json;
using NotesApp.Model;
using NotesApp.ViewModel;

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

        private string Uri => $"http://notesservice.azurewebsites.net/api/{SettingsService.Instance.TenantId}/Notes";

        private readonly HttpClient client = new HttpClient();

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            var json = await client.GetStringAsync(Uri);
            var notes = JsonConvert.DeserializeObject<IEnumerable<Note>>(json);
            return notes;
        }

        public async Task AddNote(Note note)
        {
            var json = JsonConvert.SerializeObject(note);
            var response = await client.PostAsync(Uri, new JsonContent(json));
            return;
        }

        public async Task SaveNote(Note note)
        {
            var json = JsonConvert.SerializeObject(note);
            await client.PutAsync($"{Uri}/{note.Id}", new JsonContent(json));
        }

        public async Task DeleteNote(Note note)
        {
            await client.DeleteAsync($"{Uri}/{note.Id}");
        }
    }

    public class JsonContent : StringContent
    {
        public JsonContent(string content) : this(content, Encoding.UTF8)
        {
        }

        private JsonContent(string content, Encoding encoding, string mediaType = "application/json")
            : base(content, encoding, mediaType)
        {
        }
    }
}
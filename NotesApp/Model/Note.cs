using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace NotesApp.Model
{
    public class Note : ObservableObject
    {
        public int Id { get; set; }

        [JsonProperty("Content")]
        public string Text { get; set; }

        [JsonProperty("CreatedAt")]
        public DateTime Time { get; set; } = DateTime.Now;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Geopoint Geopoint => new Geopoint(new BasicGeoposition()
        {
            Latitude = Latitude,
            Longitude = Longitude
        });
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;

namespace NotesApp.Model
{
    class Note : ObservableObject
    {
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        public BasicGeoposition? Position { get; set; }
    }
}
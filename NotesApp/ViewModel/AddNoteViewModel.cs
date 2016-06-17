using System;
using System.ComponentModel;
using Windows.Devices.Geolocation;
using GalaSoft.MvvmLight;
using NotesApp.Model;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class AddNoteViewModel : ViewModelBase
    {
        private Note _note;

        public AddNoteViewModel()
        {
            Note = new Note();
            GetCurrentLocation();
        }

        public Note Note
        {
            get { return _note; }
            private set
            {
                if (_note != null) _note.PropertyChanged -= NotePropertyChanged;
                _note = value;
                if (_note != null) _note.PropertyChanged += NotePropertyChanged;
            }
        }

        private void NotePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(Note.Text) || args.PropertyName == nameof(Note.Geopoint))
                RaisePropertyChanged(nameof(CanAddNote));
        }

        public bool CanAddNote => !string.IsNullOrWhiteSpace(Note.Text) && Note.Geopoint != null;

        public void AddNote()
        {
            NoteService.Instance.Notes.Add(Note);
            Note = new Note();
            GetCurrentLocation();
        }

        public void DiscardNote()
        {
            Note.Text = "";
        }

        public async void GetCurrentLocation()
        {
            var access = await Geolocator.RequestAccessAsync();

            switch (access)
            {
                case GeolocationAccessStatus.Allowed:
                    var geolocator = new Geolocator();
                    var geopositon = await geolocator.GetGeopositionAsync();
                    Note.Geopoint = geopositon.Coordinate.Point;
                    break;
                case GeolocationAccessStatus.Unspecified:
                case GeolocationAccessStatus.Denied:
                    break;
            }
        }
    }
}
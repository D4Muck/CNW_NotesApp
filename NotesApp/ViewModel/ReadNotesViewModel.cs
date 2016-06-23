using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight;
using NotesApp.Model;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class ReadNotesViewModel : ViewModelBase
    {
        public ReadNotesViewModel()
        {
        }

        public async void init()
        {
            var task = NoteService.Instance.GetLast(SettingsService.Instance.NotesShown);
            Notes.Clear();
            foreach (var note in await task)
            {
                Notes.Add(note);
            }
        }

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
    }
}
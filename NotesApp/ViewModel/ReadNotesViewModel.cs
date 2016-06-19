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
            ReadOnlyCollection<Note> notes = await NoteService.Instance.GetLast(SettingsService.Instance.NotesShown);
            foreach (var note in notes)
            {
                Notes.Add(note);
            }
        }

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();
    }
}
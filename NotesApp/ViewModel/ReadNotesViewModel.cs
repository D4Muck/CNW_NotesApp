using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using NotesApp.Model;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class ReadNotesViewModel : ViewModelBase
    {
        public ReadNotesViewModel()
        {
            Notes = new ObservableCollection<Note>(NoteService.Instance.GetLast(SettingsService.Instance.NotesShown));
        }

        public ObservableCollection<Note> Notes { get; }
    }
}
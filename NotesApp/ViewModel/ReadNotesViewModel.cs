using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class ReadNotesViewModel : ViewModelBase
    {
        public ReadNotesViewModel()
        {
            Notes = new ObservableCollection<Note>(NoteService.Instance.Notes);
        }

        public ObservableCollection<Note> Notes { get; }
    }
}
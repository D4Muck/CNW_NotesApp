using System.ComponentModel;
using GalaSoft.MvvmLight;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class AddNoteViewModel : ViewModelBase
    {
        private Note _note;

        public AddNoteViewModel()
        {
            Note = new Note();
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
            if (args.PropertyName == nameof(Note.Text)) RaisePropertyChanged(nameof(CanAddNote));
        }

        public bool CanAddNote => !string.IsNullOrWhiteSpace(Note.Text);

        public void AddNote()
        {
            NoteService.Instance.AddNote(Note);
            Note = new Note();
        }
    }
}
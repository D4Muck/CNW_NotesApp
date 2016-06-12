using System;
using System.ComponentModel;
using System.Linq;
using GalaSoft.MvvmLight;
using NotesApp.Model;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class EditNoteViewModel : ViewModelBase
    {
        private Note _note;
        private DateTime _noteId;
        private Note _persitstedNote;

        public EditNoteViewModel()
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
            if (args.PropertyName == nameof(Note.Text)) RaisePropertyChanged(nameof(CanSaveNote));
        }

        public bool CanSaveNote => !string.IsNullOrWhiteSpace(Note.Text);

        public DateTime NoteId
        {
            get { return _noteId; }
            set
            {
                _persitstedNote = NoteService.Instance.Notes.First(x => x.Time == value);
                Note.Text = _persitstedNote.Text;
                Note.Time = _persitstedNote.Time;
                _noteId = value;
            }
        }

        public void SaveNote()
        {
            _persitstedNote.Text = Note.Text;
            Note = new Note();
        }

        public void DeleteNote()
        {
            NoteService.Instance.Notes.Remove(_persitstedNote);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace NotesApp
{
    class NoteViewModel : ViewModelBase
    {
        public NoteViewModel()
        {
            Note.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Note.Text)) RaisePropertyChanged(nameof(CanAddNote));
            };
        }


        public Note Note { get; private set; } = new Note();

        public bool CanAddNote => !string.IsNullOrWhiteSpace(Note.Text);

        public void AddNote()
        {
            NoteService.Instance.AddNote(Note);
            Note = new Note();
        }
    }
}
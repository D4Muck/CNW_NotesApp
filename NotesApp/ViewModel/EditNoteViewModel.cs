﻿using System;
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

        public Note PersitstedNote
        {
            get { return _persitstedNote; }
            set
            {
                _persitstedNote = value;
                Note.Text = PersitstedNote.Text;
            }
        }

        public void SaveNote()
        {
            PersitstedNote.Text = Note.Text;
            NoteService.Instance.AddNote(PersitstedNote);
            Note = new Note();
        }

        public void DeleteNote()
        {
            NoteService.Instance.RemoveNote(PersitstedNote);
        }
    }
}
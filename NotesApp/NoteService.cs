using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    class NoteService
    {
        private readonly List<Note> _notes = new List<Note>();

        public static NoteService Instance { get; } = new NoteService();

        public ReadOnlyCollection<Note> Notes => _notes.AsReadOnly();


        public void AddNote(Note note)
        {
            _notes.Add(note);
        }
    }
}
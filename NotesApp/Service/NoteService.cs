using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace NotesApp.Service
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

        public ReadOnlyCollection<Note> GetLast(int count)
        {
            return _notes.OrderByDescending(x => x.Time).Take(count).ToList().AsReadOnly();
        }
    }
}
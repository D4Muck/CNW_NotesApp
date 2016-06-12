using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NotesApp.Model;

namespace NotesApp.Service
{
    class NoteService
    {
        public static NoteService Instance { get; internal set; } = new NoteService();
        
        public List<Note> Notes { get; } = new List<Note>();

        private IEnumerable<Note> GetOrdered()
        {
            return SettingsService.Instance.Ascending
                ? Notes.OrderBy(x => x.Time)
                : Notes.OrderByDescending(x => x.Time);
        }

        public ReadOnlyCollection<Note> GetLast(int count)
        {
            return GetOrdered().Take(count).ToList().AsReadOnly();
        }

        public ReadOnlyCollection<Note> GetAllThatContain(string search)
        {
            return GetOrdered().Where(x => x.Text.Contains(search)).ToList().AsReadOnly();
        }
    }
}
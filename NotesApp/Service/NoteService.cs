using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NotesApp.Model;

namespace NotesApp.Service
{
    class NoteService
    {
        public static NoteService Instance { get; internal set; } = new NoteService();

        private LocalStorageService _localStorageService = new LocalStorageService();

        //  public List<Note> Notes { get; } = new List<Note>();

        private async Task<IOrderedEnumerable<Note>> GetOrdered()
        {
            IEnumerable<Note> notes = await GetNotes();

            return SettingsService.Instance.Ascending
                ? notes.OrderBy(x => x.Time)
                : notes.OrderByDescending(x => x.Time);
        }

        public async Task<ReadOnlyCollection<Note>> GetLast(int count)
        {
            return (await GetOrdered()).Take(count).ToList().AsReadOnly();
        }

        public async Task<ReadOnlyCollection<Note>> GetAllThatContain(string search)
        {
            return (await GetOrdered()).Where(x => x.Text.Contains(search)).ToList().AsReadOnly();
        }

        public Task AddNote(Note note)
        {
            return _localStorageService.AddNote(note);
        }

        public Task RemoveNote(Note note)
        {
            return _localStorageService.DeleteNote(note);
        }

        public Task<IEnumerable<Note>> GetNotes()
        {
            return _localStorageService.GetAllNotes();
        }
    }
}
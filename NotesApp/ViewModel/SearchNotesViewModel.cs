using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApp.Model;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class SearchNotesViewModel
    {
        public SearchNotesViewModel()
        {
            UpdateNotes();
        }

        private string _searchText = "";

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                UpdateNotes();
            }
        }

        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public void UpdateNotes()
        {
            if (SearchText != null)
            {
                Notes.Clear();
                foreach (var note in NoteService.Instance.GetAllThatContain(SearchText))
                {
                    Notes.Add(note);
                }
            }
        }
    }
}
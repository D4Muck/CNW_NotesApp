using NotesApp.ViewModel;

namespace NotesApp.Service
{
    class ViewModelLocator
    {
        public AddNoteViewModel AddNoteViewModel => new AddNoteViewModel();

        public ReadNotesViewModel ReadNotesViewModel => new ReadNotesViewModel();

        public SettingsViewModel SettingsViewModel => new SettingsViewModel();

        public SearchNotesViewModel SearchNotesViewModel => new SearchNotesViewModel();

        public EditNoteViewModel EditNoteViewModel => new EditNoteViewModel();
    }
}
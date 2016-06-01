using NotesApp.ViewModel;

namespace NotesApp.Service
{
    class ViewModelLocator
    {
        public AddNoteViewModel AddNoteViewModel => new AddNoteViewModel();

        public ReadNotesViewModel ReadNotesViewModel => new ReadNotesViewModel();
    }
}
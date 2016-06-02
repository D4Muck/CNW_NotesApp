using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using NotesApp.Service;

// Die Vorlage "Leere Seite" ist unter http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 dokumentiert.

namespace NotesApp.View
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonNewNote_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(AddNotePage));
        }

        private void ButtonReadNotes_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(ReadNotesPage));
        }

        private void ButtonSettings_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(SettingsPage));
        }

        private void ButtonSearchNotes_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(SearchNotesPage));
        }
    }
}
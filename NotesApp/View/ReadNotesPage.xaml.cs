using System.Linq;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Views;
using NotesApp.Model;
using NotesApp.Service;
using NotesApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReadNotesPage : Page
    {
        public ReadNotesPage()
        {
            this.InitializeComponent();
        }

        private ReadNotesViewModel ViewModel => DataContext as ReadNotesViewModel;

        private void Notes_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var first = e.AddedItems.First() as Note;
            if (first != null) NoteNavigationService.Instance.NavigateTo(nameof(EditNotePage), first.Time);
        }
    }
}
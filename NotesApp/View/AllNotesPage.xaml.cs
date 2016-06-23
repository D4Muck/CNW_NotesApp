using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NotesApp.Model;
using NotesApp.Service;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllNotesPage : Page
    {
        public ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public AllNotesPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var task = NoteService.Instance.GetNotes();
            Notes.Clear();
            foreach (var note in await task)
            {
                Notes.Add(note);
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var note = button.DataContext as Note;

                if (note != null)
                {
                    NoteNavigationService.Instance.NavigateTo(nameof(NoteDetailPage), note);
                }
            }
        }
    }
}
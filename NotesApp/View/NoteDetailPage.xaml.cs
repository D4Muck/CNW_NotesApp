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
    public sealed partial class NoteDetailPage : Page
    {
        private Note Note { get; set; }

        private ObservableCollection<Note> Notes { get; } = new ObservableCollection<Note>();

        public NoteDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Note = e.Parameter as Note;
            ContentPresenter.Content = e.Parameter;
            Notes.Add(Note);
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(EditNotePage), Note);
        }
    }
}
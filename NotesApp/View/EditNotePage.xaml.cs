using NotesApp.ViewModel;
using System;
using System.Collections.Generic;
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
using NotesApp.Service;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditNotePage : Page
    {
        public EditNotePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var id = e.Parameter as DateTime? ?? new DateTime();

            ViewModel.NoteId = id;
        }

        private EditNoteViewModel ViewModel => DataContext as EditNoteViewModel;

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteNote();
            NoteNavigationService.Instance.GoBack();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveNote();
            NoteNavigationService.Instance.GoBack();
        }
    }
}
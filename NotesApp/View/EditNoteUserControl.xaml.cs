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
using NotesApp.Model;
using NotesApp.Service;
using NotesApp.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NotesApp.View
{
    public sealed partial class EditNoteUserControl : UserControl
    {
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(EditNoteUserControl),
                new PropertyMetadata(null, NoteChanged));

        private static void NoteChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var userControl = dependencyObject as EditNoteUserControl;
            if (userControl != null && dependencyPropertyChangedEventArgs.NewValue != null)
            {
                userControl.ViewModel.PersitstedNote = userControl.Note;
            }
        }

        private EditNoteViewModel ViewModel => DataContext as EditNoteViewModel;

        public Note Note
        {
            get { return (Note) GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        private async void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.DeleteNote();
            NoteNavigationService.Instance.GoBack();
        }

        private async void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            await ViewModel.SaveNote();
            NoteNavigationService.Instance.GoBack();
        }

        public EditNoteUserControl()
        {
            this.InitializeComponent();
        }
    }
}
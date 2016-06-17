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
    public sealed partial class NoteDetailUserControl : UserControl
    {
        public static readonly DependencyProperty NoteProperty =
            DependencyProperty.Register("Note", typeof(Note), typeof(NoteDetailUserControl),
                new PropertyMetadata(null, NoteChanged));

        private static void NoteChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var userControl = dependencyObject as NoteDetailUserControl;
            if (userControl != null && dependencyPropertyChangedEventArgs.NewValue != null)
            {
                userControl.ViewModel.NoteId = userControl.Note.Time;
            }
        }

        private EditNoteViewModel ViewModel => DataContext as EditNoteViewModel;

        public Note Note
        {
            get { return (Note) GetValue(NoteProperty); }
            set { SetValue(NoteProperty, value); }
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteNote();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            ViewModel.SaveNote();
        }

        public NoteDetailUserControl()
        {
            this.InitializeComponent();
        }
    }
}
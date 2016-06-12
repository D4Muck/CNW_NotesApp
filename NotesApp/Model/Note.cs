using System;
using GalaSoft.MvvmLight;

namespace NotesApp.Model
{
    class Note : ObservableObject
    {
        public string Text { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
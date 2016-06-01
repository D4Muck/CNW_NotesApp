using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace NotesApp
{
    class Note : ObservableObject
    {
        public string Text { get; set; }
        public DateTime Time { get; } = DateTime.Now;
    }
}
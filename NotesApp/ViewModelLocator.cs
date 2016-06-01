using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp
{
    class ViewModelLocator
    {
        public NoteViewModel NoteViewModel => new NoteViewModel();
    }
}
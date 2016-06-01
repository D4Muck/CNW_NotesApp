using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Service
{
    class SettingsService
    {
        public static SettingsService Instance { get; } = new SettingsService();

        public int NotesShown { get; set; } = 5;
    }
}
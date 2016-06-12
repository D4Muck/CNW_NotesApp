using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Service
{
    class SettingsService
    {
        public static SettingsService Instance { get; private set; } = new SettingsService();

        public int NotesShown { get; set; } = 5;

        public bool Ascending { get; set; } = false;

        public static void SaveData()
        {
            LocalStorageService.Write("settings", Instance);
            LocalStorageService.Write("notes", NoteService.Instance);
        }

        public static void LoadData()
        {
            Instance = LocalStorageService.Read<SettingsService>("settings");
            NoteService.Instance = LocalStorageService.Read<NoteService>("notes");
        }
    }
}
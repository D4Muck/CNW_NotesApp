using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using NotesApp.Service;

namespace NotesApp.ViewModel
{
    class SettingsViewModel : ViewModelBase
    {
        private string _notesShown = SettingsService.Instance.NotesShown.ToString();
        private bool _ascending = SettingsService.Instance.Ascending;


        public string NotesShown
        {
            get { return _notesShown; }
            set
            {
                int number;
                if (int.TryParse(value, out number))
                {
                    SettingsService.Instance.NotesShown = number;
                }
                _notesShown = value;
            }
        }

        public bool Ascending
        {
            get { return _ascending; }
            set
            {
                SettingsService.Instance.Ascending = value;
                _ascending = value;
            }
        }

        public void PersistData()
        {
            SettingsService.SaveData();
        }

        public void LoadData()
        {
            SettingsService.LoadData();
            NotesShown = SettingsService.Instance.NotesShown.ToString();
            Ascending = SettingsService.Instance.Ascending;
        }
    }
}
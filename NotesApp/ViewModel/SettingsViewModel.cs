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
    }
}
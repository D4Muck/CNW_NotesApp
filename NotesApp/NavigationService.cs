using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace NotesApp
{
    class NoteNavigationService
    {
        public static NoteNavigationService Instance { get; } = new NoteNavigationService();

        private NavigationService NavigationService { get; } = new NavigationService();

        private NoteNavigationService()
        {
            NavigationService.Configure(nameof(MainPage), typeof(MainPage));
            NavigationService.Configure(nameof(AddNotePage), typeof(AddNotePage));
        }

        public void NavigateTo(string key)
        {
            NavigationService.NavigateTo(key);
        }
    }
}
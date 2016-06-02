using GalaSoft.MvvmLight.Views;

namespace NotesApp.Service
{
    class NoteNavigationService
    {
        public static NoteNavigationService Instance { get; } = new NoteNavigationService();

        private NavigationService NavigationService { get; } = new NavigationService();

        private NoteNavigationService()
        {
            NavigationService.Configure(nameof(View.MainPage), typeof(View.MainPage));
            NavigationService.Configure(nameof(View.AddNotePage), typeof(View.AddNotePage));
            NavigationService.Configure(nameof(View.ReadNotesPage), typeof(View.ReadNotesPage));
            NavigationService.Configure(nameof(View.SettingsPage), typeof(View.SettingsPage));
            NavigationService.Configure(nameof(View.SearchNotesPage), typeof(View.SearchNotesPage));
        }

        public void NavigateTo(string key)
        {
            NavigationService.NavigateTo(key);
        }
    }
}
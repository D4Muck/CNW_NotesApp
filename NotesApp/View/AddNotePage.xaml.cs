using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using NotesApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNotePage : Page
    {
        public AddNotePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);


            ((App) Application.Current).OnBackRequested += (sender, args) =>
            {
                if (ViewModel.CanAddNote)
                {
                    args.Handled = true;

                    var dialog = new MessageDialog("You have unsaved changes! If you dont't want to save your note, discard it before going back!");
                    dialog.Title = "Unsaved Changes";
                    dialog.Commands.Add(new UICommand("Ok") {Id = 0});

                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 0;


#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                    dialog.ShowAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                }
            };
        }

        private AddNoteViewModel ViewModel => DataContext as AddNoteViewModel;
    }
}
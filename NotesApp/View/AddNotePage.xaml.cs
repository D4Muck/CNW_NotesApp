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
                    var dialog = new MessageDialog("Your note will not be saved if you are leaving!");
                    dialog.Commands.Add(new UICommand("I don't care") {Id = 0});
                    dialog.Commands.Add(new UICommand("Abort") {Id = 1});

                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;


                    //var result = await dialog.ShowAsync();
                    //if (result != null) args.Handled = (((int) result.Id) == 0);
                }
            };
        }

        private AddNoteViewModel ViewModel => DataContext as AddNoteViewModel;
    }
}
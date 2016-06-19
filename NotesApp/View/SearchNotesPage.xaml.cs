using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.BulkAccess;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using NotesApp.Model;
using NotesApp.Service;
using NotesApp.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotesApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchNotesPage : Page
    {
        private ObservableCollection<Note> CurrentNoteCollection { get; } = new ObservableCollection<Note>();
        private Note _lastSelectedItem;

        public SearchNotesPage()
        {
            this.InitializeComponent();
        }

        private SearchNotesViewModel ViewModel => DataContext as SearchNotesViewModel;

        private Note LastSelectedItem
        {
            get { return _lastSelectedItem; }
            set
            {
                _lastSelectedItem = value;

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    //  map.Center = value.Geopoint;
                    map.MapElements.Clear();
                    map.MapElements.Add(new MapIcon()
                    {
                        Location = value.Geopoint
                    });
                });
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed


                //                CurrentNoteCollection.Clear();
                //                CurrentNoteCollection.Add(value);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter != null)
            {
                // Parameter is item ID
                var id = (DateTime) e.Parameter;
                LastSelectedItem =
                    ViewModel.Notes.Where((item) => item.Time == id).FirstOrDefault();
            }

            UpdateForVisualState(AdaptiveStates.CurrentState);

            // Don't play a content transition for first item load.
            // Sometimes, this content will be animated as part of the page transition.
            DisableContentTransitions();
        }

        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }

        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && LastSelectedItem != null)
            {
                // Resize down to the detail item. Don't play a transition.
                NoteNavigationService.Instance.NavigateTo(nameof(NoteDetailPage), LastSelectedItem);
            }

            EntranceNavigationTransitionInfo.SetIsTargetElement(MasterListView, isNarrow);
            if (DetailContentPresenter != null)
            {
                EntranceNavigationTransitionInfo.SetIsTargetElement(DetailContentPresenter, !isNarrow);
            }
        }

        private void MasterListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Note) e.ClickedItem;
            LastSelectedItem = clickedItem;

            if (AdaptiveStates.CurrentState == NarrowState)
            {
                // Use "drill in" transition for navigating from master list to detail view
                NoteNavigationService.Instance.NavigateTo(nameof(NoteDetailPage), LastSelectedItem);
            }
            else
            {
                // Play a refresh animation when the user switches detail items.
                EnableContentTransitions();
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            // Assure we are displaying the correct item. This is necessary in certain adaptive cases.
            MasterListView.SelectedItem = LastSelectedItem;
        }

        private void EnableContentTransitions()
        {
            // DetailContentPresenter.ContentTransitions.Clear();
            // DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
        }

        private void DisableContentTransitions()
        {
            //DetailContentPresenter?.ContentTransitions.Clear();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            NoteNavigationService.Instance.NavigateTo(nameof(EditNotePage), LastSelectedItem);
        }
    }

    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
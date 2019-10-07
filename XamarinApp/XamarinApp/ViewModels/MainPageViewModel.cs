using MVVMCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XamarinApp.Views;

namespace XamarinApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() => {
                TheNote = string.Empty;
                AllNotes.Clear();
            });
            SaveCommand = new Command(() => {
                AllNotes.Add(TheNote);
                TheNote = string.Empty;
            });
            SelectedNoteChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel(SelectedNote);
                var detailPage = new DetailPage();
                detailPage.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushAsync(detailPage);
                SelectedNote = string.Empty;
            });
        }

        public ObservableCollection<string> AllNotes { get; set; }

        string theNote;

        public string TheNote
        {
            get => theNote;
            set
            {
                SetProperty(ref theNote, value, nameof(TheNote));
            }
        }

        public string SelectedNote { get; set; }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command SelectedNoteChangedCommand { get; }
    }
}

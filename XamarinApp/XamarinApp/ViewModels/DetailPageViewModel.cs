﻿using MVVMCoffee.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel(string note)
        {
            DismissPageCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            
            NoteText = note;
        }

        string noteText;
        public string NoteText
        {
            get => noteText;
            set
            {
                SetProperty(ref noteText, value, nameof(NoteText));
            }
        }

        public Command DismissPageCommand { get; }
    }
}

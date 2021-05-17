using Common.Xamarin.ViewModel;
using Common.Xamarin.ViewModel.ShellAware.Attributes;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TestProject.Models;
using TestProject.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TestProject.ViewModels
{
    //[QueryProperty(nameof(Title), "title")] This calls the built in methods for setting value. If you only need simple values then this is fine.
    public class AboutViewModel : ShellAwareViewModel
    {
        [NavigationProperty("title")]
        public string Title { 
            get => GetValue<string>(); 
            set => SetValue(value); 
        }

        
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            TestCommand = new Command(async () => await GoToAsync($"//{nameof(LoginPage)}", new Dictionary<string, object> {
                                                                                               { "secret", "Oooh" },
                                                                                               { "info", new SimpleObject { Info = "passed info" } }
                                                                                            }));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand TestCommand { get; }
    }
}
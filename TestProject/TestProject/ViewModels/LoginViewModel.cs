using Common.Xamarin.ViewModel;
using Common.Xamarin.ViewModel.Attributes;
using Common.Xamarin.ViewModel.Interfaces;
using Common.Xamarin.ViewModel.ShellAware.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Models;
using TestProject.Views;
using Xamarin.Forms;

namespace TestProject.ViewModels
{
    public class LoginViewModel : ShellAwareViewModel, IResetOnNavigation
    {
        [NavigationProperty("title")]
        public string Username { get => GetValue<string>(); set => SetValue(value); }
        [QueryParameter("secret")]
        public string Password { get => GetValue<string>(); set => SetValue(value); }

        [Affects(nameof(HasInfo))]
        [QueryParameter("info")]
        public SimpleObject Info { 
            get => GetValue<SimpleObject>(); 
            set => SetValue(value); 
        }
        public bool HasInfo { get => Info?.Info != null; }

        [AffectedBy(nameof(Username), nameof(Password))]
        public bool IsValid { 
            get => !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password); 
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await GoToAsync($"//{nameof(AboutPage)}");
        }

        public void Reset()
        {
            Username = Password = string.Empty;
            Info = null;
        }
    }
}

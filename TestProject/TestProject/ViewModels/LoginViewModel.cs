using Common.Xamarin.ViewModel.Attributes;
using Common.Xamarin.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Views;
using Xamarin.Forms;

namespace TestProject.ViewModels
{
    public class LoginViewModel : BaseViewModel, IResetOnNavigation
    {
        public string Username { get => GetValue<string>(); set => SetValue(value); }
        public string Password { get => GetValue<string>(); set => SetValue(value); }

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
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        public void Reset()
        {
            Username = Password = string.Empty;
        }
    }
}

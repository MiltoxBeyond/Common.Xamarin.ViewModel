using Common.Xamarin.ViewModel.Interfaces;
using System;
using System.Collections.Generic;
using TestProject.ViewModels;
using TestProject.Views;
using Xamarin.Forms;

namespace TestProject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
        }

        private Page _lastPage;

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            _lastPage = CurrentPage;
            base.OnNavigating(args);
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            if (_lastPage?.BindingContext is IResetOnNavigation iR) iR.Reset();
            if (_lastPage?.BindingContext is INavigationAware iNA) iNA.OnNavigatedFrom();
            base.OnNavigated(args);
            if (CurrentPage?.BindingContext is INavigationAware NA) NA.OnNavigatedTo();
        }

        internal Page CurrentPage => (Current?.CurrentItem?.CurrentItem as IShellSectionController)?.PresentedPage;

    }
}

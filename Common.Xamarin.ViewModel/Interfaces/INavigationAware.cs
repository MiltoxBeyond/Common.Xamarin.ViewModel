using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Interfaces
{
    public interface INavigationAware
    {
        void OnNavigatedTo();
        void OnNavigatedFrom();
    }
}

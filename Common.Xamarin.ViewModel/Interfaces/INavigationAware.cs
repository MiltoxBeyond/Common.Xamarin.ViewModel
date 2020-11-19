using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Interfaces
{
    /// <summary>
    /// Implement this in a ViewModel to call navigation aware events.
    /// </summary>
    public interface INavigationAware
    {
        /// <summary>
        /// Method called when Navigating To the Page
        /// </summary>
        void OnNavigatedTo();
        /// <summary>
        /// Method called when Navigating Away from the Page
        /// </summary>
        void OnNavigatedFrom();
    }
}

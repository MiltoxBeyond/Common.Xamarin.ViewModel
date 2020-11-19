using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Interfaces
{
    /// <summary>
    /// Reset called on navigation if you only are interested in resetting some values on navigating away
    /// </summary>
    public interface IResetOnNavigation
    {
        void Reset();
    }
}

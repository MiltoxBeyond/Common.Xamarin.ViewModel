using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Xamarin.ViewModel.Interfaces
{
    /// <summary>
    /// Implment this to call a 1 time asynchronous initializa method for any Class that Extends <see cref="BaseViewModel" />
    /// </summary>
    public interface IInitializeAsync
    {
        /// <summary>
        /// Asynchronous method for Initialization
        /// </summary>
        Task InitializeAsync();
    }
}

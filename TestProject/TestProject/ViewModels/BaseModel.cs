using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TestProject.Models;
using TestProject.Services;
using Xamarin.Forms;

namespace TestProject.ViewModels
{
    public class BaseModel : Common.Xamarin.ViewModel.BaseViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        public string Title
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public bool SetProperty<T>(ref T store, T value, [CallerMemberName] string propertyName = null)
        {
            store = value;
            SetValue(value, propertyName);
            return true;
        }
    }
}

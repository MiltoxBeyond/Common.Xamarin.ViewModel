using Common.Xamarin.ViewModel.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common.Xamarin.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusy { get => GetValue<bool>(); set => SetValue(value); }


        #region Property Utilities
        private IDictionary<string, object> _values { get; } = new Dictionary<string, object>();

        public event PropertyChangedEventHandler PropertyChanged;

        public T GetValue<T>([CallerMemberName] string propertyName = null) 
            => _values.ContainsKey(propertyName) && _values[propertyName] is T value ? value : default;

        public void SetValue<T>(T value, [CallerMemberName]string propertyName = null)
        {
            if(!_values.ContainsKey(propertyName) || 
                    (_values[propertyName] is T data && !EqualityComparer<T>.Default.Equals(data, value)))
            {
                _values[propertyName] = value;
                RaisePropertyChanged(propertyName);
            }
        }

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null, int depth = 0)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (depth < BaseViewModelExtensions.MaxRelationDepth)
            {
                this.RaiseRelated(depth+1, propertyName);
            }
        }

        #endregion
    }
}

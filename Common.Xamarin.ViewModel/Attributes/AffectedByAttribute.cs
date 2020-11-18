using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Attributes
{
    /// <summary>
    /// Defines Properties that are affected by another property in the viewmodel.
    /// </summary>
    /// <example>
    /// [AffectedBy(nameof(OtherProperty), ... )] 
    /// public string ThisProperty { get => GetProperty(); set => SetProperty(value); }
    /// </example>
    public class AffectedByAttribute : Attribute
    {
        /// <summary>
        /// List of Affecting Properties
        /// </summary>
        public string[] AffectedBy { get; }

        public AffectedByAttribute(params string[] affectedBy)
        {
            AffectedBy = affectedBy;
        }
    }
}

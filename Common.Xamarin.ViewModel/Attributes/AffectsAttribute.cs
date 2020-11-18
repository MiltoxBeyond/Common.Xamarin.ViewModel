using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Attributes
{
    /// <summary>
    /// Attribute that marks properties that Affect other properties
    /// </summary>
    /// <example>
    /// [Affects(nameof(OtherProperty), ... )] 
    /// public string ThisProperty { get => GetProperty(); set => SetProperty(value); }
    /// </example>
    public class AffectsAttribute : Attribute
    {
        public string[] Affects { get; }

        public AffectsAttribute(params string[] affects)
        {
            Affects = affects;
        }
    }
}

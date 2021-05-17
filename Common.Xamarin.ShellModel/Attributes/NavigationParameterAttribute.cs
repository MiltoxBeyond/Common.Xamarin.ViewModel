using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Common.Xamarin.ViewModel.ShellAware.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class NavigationParameterAttribute : QueryParameterAttribute
    {
        public NavigationParameterAttribute(string QueryID = null) : base(QueryID) { }
    }
}

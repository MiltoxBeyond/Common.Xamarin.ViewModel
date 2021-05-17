using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.ShellAware.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class QueryParameterAttribute : Attribute
    {
        public string QueryId { get; }
        public QueryParameterAttribute(string QueryID) { QueryId = QueryID; }
    }
}

using Common.Xamarin.ViewModel.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Xamarin.ViewModel.Extensions
{
    /// <summary>
    /// Extensions to the base view model to add on the ability to interact between properties.
    /// </summary>
    public static class BaseViewModelExtensions
    {
        private static AffectingCache _cache = new AffectingCache();

        public static int MaxRelationDepth { get; set; } = 2;

        public static void RaiseRelated<T>(this T self, int depth, params string[] which) where T:BaseViewModel
        {
            var type = self.GetType();
            var lookup = _cache[type];

            foreach(var item in which)
            {
                if(lookup.ContainsKey(item))
                {
                    var list = lookup[item];

                    foreach (var prop in list)
                        self.RaisePropertyChanged(prop, depth);
                }
            }
        }
    }
}

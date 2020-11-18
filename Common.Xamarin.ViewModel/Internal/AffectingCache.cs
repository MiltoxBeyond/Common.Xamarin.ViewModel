using Common.Xamarin.ViewModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.Xamarin.ViewModel.Internal
{
    /// <summary>
    /// Internal caching class to help with relationship management between properties of classes to minimize reflection repetition.
    /// </summary>
    internal class AffectingCache : Dictionary<string, AffectingCache.AffectingLookup>
    {
        /// <summary>
        /// Internal Caching class to hold properties and their affected properties.
        /// </summary>
        internal class AffectingLookup : Dictionary<string, List<string>>
        {
            
        }

        //Add types
        public AffectingLookup Add(Type type)
        {
            var key = type.FullName;
            if (ContainsKey(key))
                throw new ArgumentException("Unable to add duplicate key to type cache.");
            var result = GetAffected(type);
            Add(key, result);
            return result;
        }

        
        /// <summary>
        /// Get Affected Properties and combine with reverse lookup of affected by properties to simplify interactions.
        /// </summary>
        /// <param name="type">Type to generate the relationship map</param>
        /// <returns>Relationship AffectingLookup for mapped interactions between properties</returns>
        internal static AffectingLookup GetAffected(Type type)
        {
            var properties = type.GetProperties().Where(p => p.CanWrite || p.CanRead);
            var affects = (AffectingLookup)properties.Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(AffectsAttribute)))
                                                     .ToDictionary(p => p.Name, p => p.GetCustomAttribute<AffectsAttribute>().Affects.ToList());

            var affectedByList = properties.Where(p => p.CustomAttributes.Any(a => a.AttributeType == typeof(AffectedByAttribute)));

            foreach (var affectedProperty in affectedByList)
            {
                var affectingPropertyList = affectedProperty.GetCustomAttribute<AffectedByAttribute>()?.AffectedBy;

                foreach(var affectingProperty in affectingPropertyList)
                {
                    if(!affects.ContainsKey(affectingProperty) )
                    {
                        affects[affectingProperty] = new List<string>();
                    }
                    affects[affectingProperty].Add(affectedProperty.Name);
                }
            }

            return affects;
        }

        public AffectingLookup this[Type type] => ContainsKey(type.FullName) ? this[type.FullName] : Add(type); 
    }
}

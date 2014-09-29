namespace CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            IEnumerable<T> newCollection = collection.ToArray();
            for (int i = 0; i < count; i++)
            {
                newCollection = newCollection.Concat(collection);
            }

            return newCollection;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            var filtered = new List<string>();
            foreach (var item in collection)
            {
                foreach (var suffix in suffixes)
	            {
                    if (item.EndsWith(suffix))
                    {
                        filtered.Add(item);
                    }
	            }
             }

            return (IEnumerable<string>)filtered;
        }

        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> filtered = new List<T>();
            foreach (var item in collection)
            {
                if (!predicate(item))
                {
                    filtered.Add(item);
                }
            }

            return (IEnumerable<T>)filtered;
        }
    }
}

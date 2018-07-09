using System;
using System.Collections.Generic;
using System.Linq;

namespace Kelson.Common.CodeGen
{
    public static class Extensions
    {
        /// <summary>
        /// Converts a possibly-null array to an enumerable
        /// </summary>            
        public static IEnumerable<T> AsAll<T>(this T[] array)
        {
            if (array == null)
                yield break;
            foreach (var item in array)
                yield return item;
        }

        public static string Text(this ISourceNode node) => node.Prefix().Single();

        public static IEnumerable<string> SelectText(this ISourceNode[] nodes) => nodes.AsAll().Select(n => n.Text());

        public static bool Exist<T>(this T[] items) => items != null && items.Length > 0;        

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
                yield return item;
            }
        }
    }
}

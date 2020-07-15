using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.HTML.Live.Demos.UI.Services.HTML;
using Aspose.Html.Rendering.Image;

namespace Aspose.HTML.Live.Demos.UI.Services.Extensions
{
	public static class EnumerableExtensions
	{

		public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> otherDictionary)
		{
			return Merge(dictionary, otherDictionary, key => key);
		}

		public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IDictionary<TKey, TValue> otherDictionary, Func<TKey, TKey> keySelector) 
		{
			return new[]
				{

					dictionary,
					otherDictionary
				}
				.SelectMany(dict => dict)
				.ToLookup(pair => pair.Key, pair => pair.Value)
				.ToDictionary(group => group.Key, group => group.First());
		}

		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var item in enumerable)
				action(item);
		}
	}
}

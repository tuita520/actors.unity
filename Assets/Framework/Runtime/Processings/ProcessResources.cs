//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games


using System.Collections.Generic;
using UnityEngine;

namespace Pixeye
{
	public class ProcessResources
	{
		public static ProcessResources Default;

		Dictionary<string, Object> items = new Dictionary<string, Object>();


		public static T Get<T>(string id) where T : Object
		{
			#if HOMEBREW_EDIT
			return Resources.Load<T>(id);
			#else
			Object obj;
			var    hasValue = Default.items.TryGetValue(id, out obj);
			if (hasValue == false)
			{
				obj = Resources.Load<T>(id);
				Default.items.Add(id, obj);
			}

			return obj as T;
			#endif
		}

		public static T GetPrefab<T>(string id) where T : Object
		{
			Object obj;
			var    hasValue = Default.items.TryGetValue(id, out obj);

			if (hasValue == false)
			{
				obj = Resources.Load(id) as GameObject;
				Default.items.Add(id, obj);
			}

			return obj as T;
		}
	}
}
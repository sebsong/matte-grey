﻿using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable]
public class SerializableDictionary : Dictionary<string, GameObject>, ISerializationCallbackReceiver
{
	[SerializeField]
	private List<string> keys = new List<string>();

	[SerializeField]
	private List<GameObject> values = new List<GameObject>();

	// save the dictionary to lists
	public void OnBeforeSerialize()
	{
		keys.Clear();
		values.Clear();
		foreach(KeyValuePair<string, GameObject> pair in this)
		{
			keys.Add(pair.Key);
			values.Add(pair.Value);
		}
	}

	// load dictionary from lists
	public void OnAfterDeserialize()
	{
		this.Clear();

		if(keys.Count != values.Count)
			throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

		for(int i = 0; i < keys.Count; i++)
			this.Add(keys[i], values[i]);
	}
}
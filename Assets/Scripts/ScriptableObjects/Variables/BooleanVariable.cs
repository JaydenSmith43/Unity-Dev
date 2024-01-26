using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Boolean")]
public class BooleanVariable : ScriptableObject, ISerializationCallbackReceiver
{
	public int initialValue;

	[NonSerialized] //so it can't be changed in inspector
	public int value;

	public void OnBeforeSerialize()
	{
		value = initialValue;
	}

	public void OnAfterDeserialize()
	{
		//
	}
}

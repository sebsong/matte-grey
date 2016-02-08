using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lane {
	private List<Key> _keys;
	private bool isActive;
	private float speed;
	private int index;

	public bool IsActive { get; set; }
	public float Speed { get; private set; }

	public Lane(float speed) {
		_keys = new List<Key> ();
		this.speed = speed;
	}

	public void AddKey(Key key) {
		_keys.Add (key);
	}

	public bool HasNext() {
		return index > _keys.Count - 1;
	}

	public Key Peek() {
		return _keys [index];
	}

	public void Next() {
		index++;
	}
}

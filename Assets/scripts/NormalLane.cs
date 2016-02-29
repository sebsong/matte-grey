using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormalLane : MonoBehaviour, Lane {
	public List<GameObject> Keys { get; private set; }
	public bool IsActive { get; private set; }
	public float Speed { get; private set; }

	// Use this for initialization
	void Start () {
		Keys = new List<GameObject> ();
		Speed = 3f;
	}

	public void AddKey(GameObject key) {
		Keys.Add (key);
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject key in Keys) {
			if (key.activeSelf) {
				key.transform.position -= Vector2.left * Speed * Time.deltaTime;
			}
		}
	}
}

using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class NormalLane : MonoBehaviour, Lane {
	public List<GameObject> Keys { get; set; }
	public bool IsActive { get; set; }
	public float Speed { get; set; }

	// Use this for initialization
	void Awake () {
		Keys = new List<GameObject> ();
		Speed = 0.5f;
		IsActive = true;
	}

	public void AddKey(GameObject key, string text) {
		Keys.Add (key);
		Key keyComponent = key.GetComponent<Key> ();
		keyComponent.Text = text;
		keyComponent.parentLane = this;
	}

	public void CheckKey (string input) {
		if (Keys.Count > 0) {
			Key fringeKey = Keys [0].GetComponent<Key>();
			if (input.Equals (fringeKey.Text)) {
				Keys.RemoveAt (0);
				fringeKey.CastSpell ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject key in Keys) {
			if (key.activeSelf) {
				key.transform.position += Vector3.left * Speed * Time.deltaTime;
			}
		}
	}
}

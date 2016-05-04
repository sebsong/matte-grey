using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public abstract class Lane : MonoBehaviour {

	/* Keys in the lane */
	public List<GameObject> Keys { get; set; }

	/* Whether keys are typable in this lane */
	public bool IsActive { get; set; }

	/* Speed of the keys in the lane */
	public float Speed { get; set; }

	protected virtual void Awake () {
		Keys = new List<GameObject> ();
		IsActive = true;
	}

	/* Adds KEY to the list of keys */
	public void AddKey(GameObject key, string text) {
		Keys.Add (key);
		Key keyComponent = key.GetComponent<Key> ();
		keyComponent.Text = text;
		keyComponent.parentLane = this;
	}

	/* Checks if the input matches the first key text, if so, cast key spell, else, do nothing */
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

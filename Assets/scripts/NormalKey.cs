using UnityEngine;
using System.Collections;

public class NormalKey : MonoBehaviour, Key {

	public string Text { get; set; }

	public void CastSpell() {
		/* Do nothing */
		gameObject.SetActive (false);
	}

	public void Update() {
	}
}

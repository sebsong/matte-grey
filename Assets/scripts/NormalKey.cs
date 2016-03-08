using UnityEngine;
using System.Collections;

public class NormalKey : MonoBehaviour, Key {

	public string Text { get; set; }

	public Lane parentLane { get; set; }

	public void CastSpell() {
		/* Do nothing */
		gameObject.SetActive (false);
	}

	public void HitEnd () {
		parentLane.Keys.Remove (gameObject);
		gameObject.SetActive (false);
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "laneEnd") {
			HitEnd ();
		}
	}
}

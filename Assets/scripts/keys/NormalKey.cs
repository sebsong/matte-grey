using UnityEngine;
using System.Collections;

public class NormalKey : MonoBehaviour, Key {

	public string Text { get; set; }

	public Lane parentLane { get; set; }

	PlayerController player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
	}

	public void CastSpell() {
		/* Do nothing */
		gameObject.SetActive (false);
	}

	public void HitEnd () {
		player.TakeDamage (2);
		parentLane.Keys.Remove (gameObject);
		gameObject.SetActive (false);
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "laneEnd") {
			HitEnd ();
		}
	}
}

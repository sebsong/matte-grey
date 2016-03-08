using UnityEngine;
using System.Collections;

public class HealKey : MonoBehaviour, Key {
	public string Text { get; set; }

	public Lane parentLane { get; set; }

	PlayerController player;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
	}

	public void CastSpell() {
		player.TakeDamage (-5);
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

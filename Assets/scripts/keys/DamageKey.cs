using UnityEngine;
using System.Collections;

public class DamageKey : MonoBehaviour, Key {
	public string Text { get; set; }

	public Lane parentLane { get; set; }

	public AudioClip keyCastClip;

	PlayerController player;
	EnemyController enemy;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
		enemy = GameObject.FindGameObjectWithTag ("enemy").GetComponent<EnemyController> ();
	}

	public void CastSpell() {
		enemy.TakeDamage (10);
		gameObject.SetActive (false);
	}

	public void HitEnd () {
		AudioSource.PlayClipAtPoint (keyCastClip, transform.position);
		player.TakeDamage (5);
		parentLane.Keys.Remove (gameObject);
		gameObject.SetActive (false);
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "laneEnd") {
			HitEnd ();
		}
	}
}

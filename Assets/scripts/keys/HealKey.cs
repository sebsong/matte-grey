using UnityEngine;
using System.Collections;

public class HealKey : MonoBehaviour, Key {
	public string Text { get; set; }

	public Lane parentLane { get; set; }

	PlayerController player;
	EnemyController enemy;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
		enemy = GameObject.FindGameObjectWithTag ("enemy").GetComponent<EnemyController> ();
	}

	public void CastSpell() {
		player.TakeDamage (-5);
		gameObject.SetActive (false);
	}

	public void HitEnd () {
		enemy.TakeDamage (-3);
		parentLane.Keys.Remove (gameObject);
		gameObject.SetActive (false);
	}

	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "laneEnd") {
			HitEnd ();
		}
	}
}

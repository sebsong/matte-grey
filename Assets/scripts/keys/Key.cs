using UnityEngine;
using System.Collections;

public abstract class Key : MonoBehaviour {
	/* Text to type */
	public string Text { get; set; }

	/* The lane that this key is in */
	public Lane parentLane { get; set; }

	/* Audio clip to be played when key hits a laneEnd */
	public AudioClip keyHitClip;

	/* Player and enemy script references */
	protected PlayerController player;
	protected EnemyController enemy;

	void Start() {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
		enemy = GameObject.FindGameObjectWithTag ("enemy").GetComponent<EnemyController> ();
	}

	/* Effect when typed */
	public virtual void CastSpell() {
		gameObject.SetActive (false);
	}

	/* Effect when key hits end of board */
	public virtual void HitEnd () {
		AudioSource.PlayClipAtPoint (keyHitClip, transform.position);
		parentLane.Keys.Remove (gameObject);
		gameObject.SetActive (false);
	}

	/* Collision detection */
	public void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "laneEnd") {
			HitEnd ();
		}
	}
}

using UnityEngine;
using System.Collections;

public interface Key {
	/* Text to type */
	string Text { get; set; }

	/* The lane that this key is in */
	Lane parentLane { get; set; }

	/* Effect when typed */
	void CastSpell();

	/* Effect when key hits end of board */
	void HitEnd();

	/* Collision detection */
	void OnCollisionEnter2D (Collision2D col);
}

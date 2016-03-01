using UnityEngine;
using System.Collections;

public interface Key {
	/* Text to type */
	string Text { get; set; }

	/* Effect when typed */
	void CastSpell();
}

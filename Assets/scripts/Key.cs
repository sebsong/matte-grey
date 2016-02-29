using UnityEngine;
using System.Collections;

public interface Key {
	/* Text to type */
	string Text { get; }

	/* Effect when typed */
	void CastSpell();
}

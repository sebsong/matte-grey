using UnityEngine;
using System.Collections;

public abstract class Key{
	public string Text { get; private set; }

	protected Key(string text) {
		Text = text;
	}

	public abstract void CastSpell();
}

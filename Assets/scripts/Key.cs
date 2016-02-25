using UnityEngine;
using System.Collections;

public abstract class Key{
	public string Text { get; private set; }

	protected Key(string text) {
		Text = Text;
	}

	public abstract void CastSpell();
}

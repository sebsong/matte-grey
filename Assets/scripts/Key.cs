using UnityEngine;
using System.Collections;

public abstract class Key{
	string text;
	public string Text{get;}

	protected Key(string text) {
		this.text = text;
	}

	public abstract void CastSpell();
}

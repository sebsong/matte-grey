using UnityEngine;
using System.Collections;

public class HealKey : Key {

	public override void CastSpell() {
		player.TakeDamage (-4);
		base.CastSpell ();
	}

	public override void HitEnd () {
		enemy.TakeDamage (-7);
		base.HitEnd ();
	}
}

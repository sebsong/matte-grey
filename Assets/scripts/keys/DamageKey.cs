using UnityEngine;
using System.Collections;

public class DamageKey : Key {

	public override void CastSpell() {
		enemy.TakeDamage (10);
		base.CastSpell ();
	}

	public override void HitEnd () {
		player.TakeDamage (7);
		base.HitEnd ();
	}
}

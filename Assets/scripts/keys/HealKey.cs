using UnityEngine;
using System.Collections;

public class HealKey : Key {

	public override void CastSpell() {
		player.TakeDamage (-5);
		base.CastSpell ();
	}

	public override void HitEnd () {
		enemy.TakeDamage (-3);
		base.HitEnd ();
	}
}

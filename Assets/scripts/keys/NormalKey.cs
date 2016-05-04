using UnityEngine;
using System.Collections;

public class NormalKey : Key {

	public override void HitEnd () {
		player.TakeDamage (2);
		base.HitEnd ();
	}
}

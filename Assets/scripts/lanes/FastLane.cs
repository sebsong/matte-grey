using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FastLane : Lane {

	protected override void Awake () {
		Speed = 1f;
		base.Awake ();
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReverseLane : Lane {

	protected override void Awake () {
		Speed = -0.5f;
		base.Awake ();
	}
}

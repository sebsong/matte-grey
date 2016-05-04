using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class NormalLane : Lane {

	protected override void Awake () {
		Speed = 0.5f;
		base.Awake ();
	}

}

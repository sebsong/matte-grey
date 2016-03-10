﻿using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public int Health { get; private set; }

	// Use this for initialization
	void Start () {
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TakeDamage(int dmg) {
		Health -= dmg;
	}
}
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int Health { get; private set; }

	// Use this for initialization
	void Start () {
		Health = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (Health > 100) {
			Health = 100;
		}
	}

	public void TakeDamage(int dmg) {
		Health -= dmg;
	}
}

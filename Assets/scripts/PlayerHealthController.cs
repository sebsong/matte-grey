using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealthController : MonoBehaviour {

	PlayerController player;

	Slider healthSlider;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("player").GetComponent<PlayerController> ();
		healthSlider = GameObject.FindGameObjectWithTag("playerHealth").GetComponent<Slider> ();

	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = player.Health;
		if (player.Health <= 0) {
			Utils.GameOver ();
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

	private GameObject transitionText;

	public float blinkDelay;

	private float blinkCooldown;
	private bool active;


	// Use this for initialization
	void Start () {
		transitionText = GameObject.FindWithTag ("transitionText");
		blinkCooldown = blinkDelay;
		active = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Utils.LoadNextScene ();
		} else if (blinkCooldown <= 0 || blinkCooldown == blinkDelay) {
			transitionText.SetActive (active);
			blinkCooldown = blinkDelay;
			active = !active;
		}
		blinkCooldown -= Time.deltaTime;
	}
}

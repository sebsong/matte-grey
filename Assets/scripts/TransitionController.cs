using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour {

	private GameObject transitionText;

	public float blinkDelay;

	private float blinkCooldown;
	private bool active;

    private float minSeconds;


	// Use this for initialization
	void Start () {
		transitionText = GameObject.FindWithTag ("transitionText");
		blinkCooldown = blinkDelay;
		active = true;
        minSeconds = 1;
	}
	
	// Update is called once per frame
	void Update () {
        minSeconds -= Time.deltaTime;
		if (minSeconds < 0 && Input.anyKey) {
			Utils.LoadNextScene ();
		} else if (blinkCooldown <= 0 || blinkCooldown == blinkDelay) {
			transitionText.SetActive (active);
			blinkCooldown = blinkDelay;
			active = !active;
		}
		blinkCooldown -= Time.deltaTime;
	}
}

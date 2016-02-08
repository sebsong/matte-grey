using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	public Transform board;
	public Transform lane;
	public Transform key;

	private List<Lane> _lanes;
	private SpriteRenderer spriteRenderer;
	private float width;
	private float height;

	// Use this for initialization
	void Start () {
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* Instantiate the necessary keys and lanes. (might not use) */
	void FillBoard() {
	}

	/* Parse STORY and return a list of keys. */
	List<Key> ParseStory(string story) {
		return null;
	}

	/* Fill _LANES with KEYS. */
	void FillLanes(List<Key> keys) {
	}
}

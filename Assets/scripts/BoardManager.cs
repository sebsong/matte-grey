using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	/* Lane and Key prefab */
	public Transform lane;
	public Transform key;

	private List<Lane> _lanes;
	private SpriteRenderer boardSR;
	private float boardWidth;
	private float boardHeight;
	private float boardScaleX;
	private float boardScaleY;

	// Use this for initialization
	void Start () {
		_lanes = new List<Lane> ();
		SpriteRenderer boardSR = GetComponent<SpriteRenderer> ();
		boardWidth = boardSR.bounds.size.x;
		boardHeight = boardSR.bounds.size.y;
		boardScaleX = transform.localScale.x;
		boardScaleY = transform.localScale.y;

		for (int i = 0; i < 3; i++) {
			_lanes.Add (new Lane (i));
		}

		string s1 = "potatoadsfadsfdsafdsklafjklsdafjlkdsajflkasdjlkfjsdlkjfklsdjladsf";
		foreach (Lane l in _lanes) {
			for (int i = 0; i < 10; i++) {
				if (i + i < s1.Length)
				l.AddKey (new NormalKey (s1.Substring(i, i)));
			}
		}
		PositionPieces ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (char c in Input.inputString) {
			print (c);
		}
	}

	/* Instantiate the necessary lanes and keys and position them in the game board, resizing as necessary. */
	void PositionPieces() {
		int numLanes = _lanes.Count;

		float laneWidth = boardWidth;
		float laneHeight = boardHeight / numLanes;

		float laneScaleX = boardScaleX;
		float laneScaleY = boardScaleY / numLanes;

		float keyOffset = 0.5f;
		Vector3 lanePos = transform.position + (Vector3.up * ((laneHeight - boardHeight) / 2));

		foreach (Lane l in _lanes) {
			Transform newLane = (Transform) Instantiate (lane, lanePos, Quaternion.identity);
			newLane.localScale = new Vector3 (laneScaleX, laneScaleY);
			List<Key> laneKeys = l.GetKeys ();

			Vector3 keyPos = newLane.position + (Vector3.right * ((laneWidth) / 2 - keyOffset)) ;

			foreach (Key k in laneKeys) {

				Transform newKey = (Transform)Instantiate (key, keyPos, Quaternion.identity);

				TextMesh keyText = newKey.GetComponent<TextMesh> ();

				keyText.text = k.Text;

				float textWidth = keyText.characterSize * k.Text.Length;

				Transform background = newKey.GetChild (0);

				float oldBackgroundWidth = background.GetComponent<SpriteRenderer> ().bounds.size.x;

				float backgroundWidth = textWidth * 0.6f;
				float backgroundHeight = 0.8f * laneHeight;

				float backgroundScaleX = (backgroundWidth / oldBackgroundWidth) * background.localScale.x;
				float backgroundScaleY = 0.8f * laneScaleY;

				background.localScale = new Vector3 (backgroundScaleX, backgroundScaleY);

				keyPos += Vector3.right * (background.GetComponent<SpriteRenderer>().bounds.size.x + keyOffset);
			}

			lanePos += Vector3.up * laneHeight;
		}
	}

	/* Parse STORY and return a list of keys. */
	List<Key> ParseStory(string story) {
		return null;
	}

	/* Fill _LANES with KEYS. */
	void FillLanes(List<Key> keys) {
		
	}
}

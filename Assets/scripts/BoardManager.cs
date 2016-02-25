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

		string s1 = "potato";
		foreach (Lane l in _lanes) {
			for (int i = 0; i < 5; i++) {
				l.AddKey (new NormalKey ("hi"));
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

		float keySize = 0.8f * laneHeight;

		float keyScale = 0.5f * laneScaleY;
		float keyOffset = 0.5f;
		Vector3 lanePos = transform.position + (Vector3.up * ((laneHeight - boardHeight) / 2));

		foreach (Lane l in _lanes) {
			Transform newLane = (Transform) Instantiate (lane, lanePos, Quaternion.identity);
			newLane.localScale = new Vector3 (laneScaleX, laneScaleY);
			List<Key> laneKeys = l.GetKeys ();

			Vector3 keyPos = newLane.position + (Vector3.right * ((laneWidth + keySize) / 2 - keyOffset)) ;

			foreach (Key k in laneKeys) {
				Transform newKey = (Transform)Instantiate (key, keyPos, Quaternion.identity);
				newKey.localScale = new Vector3 (keyScale, keyScale);
				print (k.Text);
				newKey.GetChild (0).GetComponent<TextMesh> ().text = k.Text;
				keyPos += Vector3.right * (keySize + keyOffset);
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

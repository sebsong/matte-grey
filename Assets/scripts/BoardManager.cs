using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class BoardManager : MonoBehaviour {
	/* Lane and Key prefab */
	public GameObject lane;
	public GameObject key;
	private Text inputDisplay;

	private List<GameObject> _lanes;
	private StringBuilder inputText;

	private SpriteRenderer boardSR;
	private float boardWidth;
	private float boardHeight;
	private float boardScaleX;
	private float boardScaleY;

	// Use this for initialization
	void Start () {
		_lanes = new List<GameObject> ();
		inputText = new StringBuilder ();
		inputDisplay = GameObject.Find ("InputDisplay").GetComponent<Text> ();

		SpriteRenderer boardSR = GetComponent<SpriteRenderer> ();
		boardWidth = boardSR.bounds.size.x;
		boardHeight = boardSR.bounds.size.y;
		boardScaleX = transform.localScale.x;
		boardScaleY = transform.localScale.y;

		/* Sample data */
		for (int i = 0; i < 7; i++) {
			_lanes.Add ((GameObject) Instantiate(lane, Vector3.zero, Quaternion.identity));
		}

		string s1 = "potatoadsfadsfdsafdsklafjklsdafjlkdsajflkasdjlkfjsdlkjfklsdjladsf";
		foreach (GameObject l in _lanes) {
			for (int i = 0; i < 10; i++) {
				int len = (int) (Random.value * 7);
				if (i + len < s1.Length && len > 0) {
					GameObject temp = (GameObject)Instantiate (key, Vector3.zero, Quaternion.identity);
					print (s1.Substring (i, len));
					l.GetComponent<Lane> ().AddKey (temp, s1.Substring (i, len));
				}
			}
		}
		PositionPieces ();
	}
	
	// Update is called once per frame
	void Update () {
		inputDisplay.text = inputText.ToString ();
		if (Input.GetKeyDown ("enter") || Input.GetKeyDown ("return")) {
			foreach (GameObject l in _lanes) {
				Lane lane = l.GetComponent<Lane> ();
				if (lane.IsActive) {
					lane.CheckKey (inputText.ToString ());
				}
			}
			inputText.Length = 0;
		} else if (Input.GetKeyDown("backspace") || Input.GetKeyDown("delete")) {
			if (inputText.Length > 0) {
				inputText.Remove (inputText.Length - 1, 1);
			}
		} else {
			foreach (char c in Input.inputString) {
				inputText.Append (c);
			}
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

		foreach (GameObject l in _lanes) {
			l.transform.position = lanePos;
			l.transform.localScale = new Vector3 (laneScaleX, laneScaleY);
			List<GameObject> laneKeys = l.GetComponent<Lane> ().Keys;

			Vector3 keyPos = l.transform.position + (Vector3.right * ((laneWidth) / 2 - keyOffset)) ;

			foreach (GameObject k in laneKeys) {
				Key key = k.GetComponent<Key> ();

				k.transform.position = keyPos;

				TextMesh keyText = k.GetComponent<TextMesh> ();

				keyText.text = key.Text;

				float textWidth = keyText.characterSize * key.Text.Length;

				Transform background = k.transform.GetChild (0);

				float oldBackgroundWidth = background.GetComponent<SpriteRenderer> ().bounds.size.x;

				float backgroundWidth = textWidth * 0.6f;

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

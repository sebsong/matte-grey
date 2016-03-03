using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class BoardManager : MonoBehaviour {
	/* Lane and Key prefab */
	public GameObject normalLane;
	public GameObject normalKey;

	public int numLanes;

	private StreamReader story;
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

		FillBoard ();
		ParseStory ("Assets/stories/sample.txt");
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

	/* Parse story stored at FILEPATH, instantiate keys from STORYTEXT, and populate _LANES. */
	void ParseStory(string filePath) {
		story = new StreamReader (filePath);
		string storyText = story.ReadToEnd ();
		story.Close ();

		Regex replaceReg = new Regex ("[.,()!?@#$%^&*\n\r]");
		storyText = replaceReg.Replace (storyText, " ");

		string[] keyTexts = storyText.Split (new char[] {' '}, System.StringSplitOptions.RemoveEmptyEntries);

		FillLanes (keyTexts);
	}

	/* Fill each lane in _LANES with KEYS. */
	void FillLanes(string[] keyTexts) {
		if (_lanes.Count > 0) {
			foreach (string keyText in keyTexts) {
				int laneIndex = Random.Range (0, _lanes.Count);
				GameObject keyToAdd = (GameObject)Instantiate (normalKey, Vector3.zero, Quaternion.identity);
				_lanes [laneIndex].GetComponent<Lane> ().AddKey (keyToAdd, keyText);
			}
		}
	}

	/* Fill _LANES with lanes */
	void FillBoard() {
		for (int i = 0; i < numLanes; i++) {
			_lanes.Add ((GameObject) Instantiate(normalLane, Vector3.zero, Quaternion.identity));
		}
	}
}

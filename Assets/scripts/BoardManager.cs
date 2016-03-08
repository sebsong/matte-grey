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
	public GameObject laneEnd;

	public int numLanes;

	private StreamReader story;
	private Text inputDisplay;
	private List<GameObject> _lanes;
	private StringBuilder inputText;

	private SpriteRenderer boardSR;
	private float boardWidth;
	private float boardHeight;

	// Use this for initialization
	void Start () {
		_lanes = new List<GameObject> ();
		inputText = new StringBuilder ();
		inputDisplay = GameObject.Find ("InputDisplay").GetComponent<Text> ();

		SpriteRenderer boardSR = GetComponent<SpriteRenderer> ();
		boardWidth = boardSR.bounds.size.x;
		boardHeight = boardSR.bounds.size.y;


		FillBoard ();
		ParseStory ("Assets/stories/jackjill.txt");
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

		Instantiate(laneEnd, transform.position + Vector3.left * (boardWidth / 2), Quaternion.identity);

		float newLaneWidth = boardWidth;
		float newLaneHeight = boardHeight / numLanes;
		float laneSpacing = newLaneHeight / 6;
		newLaneHeight = boardHeight / numLanes - laneSpacing;

		float keyOffset = 0.5f;
		float keyTopBotPadding = 0.25f;
		float keyTextPadding = 0.5f;

		Vector3 lanePos = transform.position + (Vector3.up * ((newLaneHeight - boardHeight + laneSpacing) / 2));

		foreach (GameObject l in _lanes) {
			SpriteRenderer laneSR = l.GetComponent<SpriteRenderer> ();
			float laneWidth = laneSR.bounds.size.x;
			float laneHeight = laneSR.bounds.size.y;

			l.transform.position = lanePos;
			float newLaneWidthScale = newLaneWidth / laneWidth;
			float newLaneHeightScale = newLaneHeight / laneHeight;
			l.transform.localScale = new Vector3 (newLaneWidthScale * l.transform.localScale.x,
												newLaneHeightScale * l.transform.localScale.y);

			Vector3 keyPos = Vector3.zero;

			List<GameObject> laneKeys = l.GetComponent<Lane> ().Keys;

			foreach (GameObject k in laneKeys) {
				Transform keyBackground = k.transform.GetChild (0);
				Key key = k.GetComponent<Key> ();
				SpriteRenderer keyBackgroundSR = keyBackground.GetComponent<SpriteRenderer> ();
				TextMesh keyText = k.GetComponent<TextMesh> ();
				MeshRenderer keyMeshRenderer = k.GetComponent<MeshRenderer> ();
				BoxCollider2D keyCollider = k.GetComponent<BoxCollider2D> ();

				float keyBackgroundWidth = keyBackgroundSR.bounds.size.x;
				float keyBackgroundHeight = keyBackgroundSR.bounds.size.y;

				keyText.text = key.Text;

				float textWidth = keyMeshRenderer.bounds.size.x + keyTextPadding;

				float newKeyBackgroundWidth = textWidth + keyTextPadding;
				float newKeyBackgroundHeight = newLaneHeight - keyTopBotPadding;

				if (keyPos == Vector3.zero) {
					keyPos = l.transform.position + (Vector3.right * ((newLaneWidth + newKeyBackgroundWidth) / 2));
				} else {
					keyPos += Vector3.right * (newKeyBackgroundWidth / 2 + keyOffset);
				}

				k.transform.position = keyPos;
				float newKeyBackgroundWidthScale = newKeyBackgroundWidth / keyBackgroundWidth;
				float newKeyBackgroundHeightScale = newKeyBackgroundHeight / keyBackgroundHeight;
				keyBackground.localScale = new Vector3 (newKeyBackgroundWidthScale * keyBackground.localScale.x,
														newKeyBackgroundHeightScale * keyBackground.localScale.y);
				keyCollider.size = new Vector2 (newKeyBackgroundWidth, newKeyBackgroundHeight) * 2.25f;

				keyPos += Vector3.right * (newKeyBackgroundWidth / 2);
			}

			lanePos += Vector3.up * (newLaneHeight + laneSpacing);
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

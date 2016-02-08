using UnityEngine;
using System.Collections;

public class KeyTextController : MonoBehaviour {
	MeshRenderer textMeshRenderer;

	// Use this for initialization
	void Start () {
		textMeshRenderer = gameObject.GetComponent<MeshRenderer> ();
		textMeshRenderer.sortingOrder = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

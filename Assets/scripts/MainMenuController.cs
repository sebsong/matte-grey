using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	public void OnStart() {
		SceneManager.LoadScene (3);
	}

	public void OnQuit() {
		Application.Quit ();
	}
}

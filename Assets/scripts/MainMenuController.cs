using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	public void OnStart() {
		Debug.Log ("Start Button pressed");
		SceneManager.LoadScene (2);
	}

	public void OnHiScores() {
		Debug.Log ("HiScores Button pressed");
	}

	public void OnOptions() {
		Debug.Log ("Options Button pressed");
	}

	public void OnQuit() {
		Debug.Log ("Quit Button pressed");
		Application.Quit ();
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverController : MonoBehaviour {

	public void MainMenu() {
		SceneManager.LoadScene (1);
	}

	public void Quit() {
		Application.Quit ();
	}
}

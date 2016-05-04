using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour {

	public static void LoadNextScene() {
		int nextScene = SceneManager.GetActiveScene ().buildIndex + 1;
		SceneManager.LoadScene (nextScene);
	}

	public static void GameOver() {
		SceneManager.LoadScene (2);
	}

}

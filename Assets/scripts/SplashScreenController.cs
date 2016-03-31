using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashScreenController : MonoBehaviour {

	public float delay;

	IEnumerator Start () {
		yield return new WaitForSeconds(delay);

		SceneManager.LoadScene (1);
	}
}

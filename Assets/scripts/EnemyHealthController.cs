using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyHealthController : MonoBehaviour {

	EnemyController enemy;
	Slider healthSlider;

	// Use this for initialization
	void Start () {
		enemy = GameObject.FindGameObjectWithTag ("enemy").GetComponent<EnemyController> ();
		healthSlider = GameObject.FindGameObjectWithTag("enemyHealth").GetComponent<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = enemy.Health;
		if (enemy.Health <= 0) {
			int nextScene = SceneManager.GetActiveScene ().buildIndex + 1;
			SceneManager.LoadScene (nextScene);
		}
	}
}

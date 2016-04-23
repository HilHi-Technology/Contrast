using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsScript : MonoBehaviour {

	void Start () {
		Vector2 v = Vector2.zero;
		v.y = 200;
		GetComponent<Rigidbody2D>().AddForce(v);
	}
	
	void Update() {
		if (transform.position.y > 30) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			SceneManager.LoadScene(0);
		}
	}
}

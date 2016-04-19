using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour {
	void OnMouseDown() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}

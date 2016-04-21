using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonScript : MonoBehaviour {
	void OnMouseDown() {
		Application.Quit();
	}
}

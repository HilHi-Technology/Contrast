using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButtonScript : MonoBehaviour {
	void OnMouseDown() {
		transform.parent.parent.GetComponent<PauseScript>().isPaused = false;
	}
}

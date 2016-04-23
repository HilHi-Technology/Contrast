using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	void Awake () {
		Debug.Log ("Music player Awake " + GetInstanceID());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player self desturcting");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Use this for initialization
	void Start () {
			Debug.Log ("Music player Start " + GetInstanceID());
			
		}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}

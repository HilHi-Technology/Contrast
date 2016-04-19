using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPressScript : MonoBehaviour {
    public string sceneName; 
    
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown(){
        SceneManager.LoadScene(sceneName);
    }
}

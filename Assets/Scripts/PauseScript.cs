﻿using UnityEngine;

public class PauseScript : MonoBehaviour {
    
    [HideInInspector]
    public bool isPaused = false;
    
    public Transform pauseGUI;  // GUI object associated with pausing.
    public Vector2 pauseGUIPosition;  // Position when paused in screenspace.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Pause") && GameObject.FindGameObjectsWithTag("Player").Length > 0){
            isPaused = !isPaused;
        }
        if(isPaused){
            print("pausing");
            Time.timeScale = 0;
            pauseGUI.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(pauseGUIPosition.x, pauseGUIPosition.y, 2));
        }
        else{
            Time.timeScale = 1;
            pauseGUI.transform.position = new Vector2(9999, 9999);
        }
	}
    void OnLevelWasLoaded(int levelIndex){
        isPaused = false;
        Time.timeScale = 1;
    }
}

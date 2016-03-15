using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

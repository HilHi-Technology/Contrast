using UnityEngine;
using System.Collections;

public class DontDestroyOnLoadScript : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	    DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1){
            Destroy(gameObject);
        }
	}
    void Update(){
        // if (FindObjectsOfType(GetType()).Length > 1){
        //     // Destroy this object if there are duplicates.
        //     Destroy(gameObject);
        // }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour {

    private List<GameObject> affectedObjects = new List<GameObject>();
    public GameObject playerObject;

	// Use this for initialization
	void Start () {
        // Find list of object that are interactable.
		GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Interactable");
		foreach (GameObject gameobject in gameobjects) {
			if (GetComponent<Renderer>().bounds.Intersects(gameobject.GetComponent<Renderer>().bounds)) {
                // For the objects that are interactable and touching the zone: 
        		gameobject.SendMessage("ZoneTrigger", gameObject);
                affectedObjects.Add(gameobject);
    		}
		}
	}
    
    public void Destroy() {
        foreach (GameObject obj in affectedObjects) {
            obj.SendMessage("ZoneReset");
        }
        affectedObjects = new List<GameObject>();
        Destroy(gameObject);
    }

}

using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour {

    private List<GameObject> affectedObjects = new List<GameObject>();

	// Use this for initialization
	void Start () {
		var gameobjects = GameObject.FindGameObjectsWithTag("Interactable");
		foreach (GameObject gameobject in gameobjects) {
			if (GetComponent<Renderer>().bounds.Intersects(gameobject.GetComponent<Renderer>().bounds)) {
        		gameobject.SendMessage("ZoneTrigger", gameObject);
                affectedObjects.Add(gameobject);
    		}
		}
	}

    void OnDestroy()
    {
        foreach (GameObject go in affectedObjects)
        {
            go.SendMessage("ZoneReset");
        }
    }

}

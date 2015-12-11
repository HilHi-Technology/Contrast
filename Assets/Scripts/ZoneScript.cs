using UnityEngine;

public class ZoneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var gameobjects = GameObject.FindGameObjectsWithTag("Interactable");
		foreach (GameObject gameobject in gameobjects) {
			if (GetComponent<Renderer>().bounds.Intersects(gameobject.GetComponent<Renderer>().bounds)) {
        		gameobject.SendMessage("ZoneTrigger", gameObject);
    		}
		}
	}
}

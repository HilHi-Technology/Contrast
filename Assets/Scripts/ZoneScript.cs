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

    void Update() {
        /*if (Input.GetButtonDown("Fire1")) {
            foreach (GameObject go in affectedObjects)
            {
                go.SendMessage("ZoneReset");
            }
            affectedObjects = new List<GameObject>();
            RaycastHit2D raycastHit2D = Physics2D.Raycast(playerObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - playerObject.transform.position, Mathf.Infinity, 1 << LayerMask.NameToLayer("Platform"));
            // This is kind of cancer code so simplify somtimes pls.
            if (raycastHit2D.point != Vector2.zero)
            {
                transform.position = new Vector3(raycastHit2D.point.x, raycastHit2D.point.y, 0);
            }
            else {
                transform.position = new Vector3(999, 999, 0);
            }
            var gameobjects = GameObject.FindGameObjectsWithTag("Interactable");
            foreach (GameObject gameobject in gameobjects)
            {
                if (GetComponent<Renderer>().bounds.Intersects(gameobject.GetComponent<Renderer>().bounds))
                {
                    gameobject.SendMessage("ZoneTrigger", gameObject);
                    affectedObjects.Add(gameobject);
                }
            }
            
        }*/
        
    }
    public void Destroy() {
        foreach (GameObject obj in affectedObjects) {
            obj.SendMessage("ZoneReset");
        }
        affectedObjects = new List<GameObject>();
        Destroy(gameObject);
    }

}

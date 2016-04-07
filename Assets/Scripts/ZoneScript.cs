using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour {

    private List<GameObject> affectedObjects = new List<GameObject>();
    public GameObject playerObject;

	// Use this for initialization
	void Update () {
        // WARNING: Possible bottleneck. Zone reset contains a call to GetComponent, which shouldn't be call on an update basis.
        foreach (GameObject obj in affectedObjects) {
            obj.SendMessage("ZoneReset");
        }
        affectedObjects = new List<GameObject>();
        
        // Find list of object that are interactable.
		GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("Interactable");
		foreach (GameObject gameobject in gameobjects) {
			if (GetComponent<Renderer>().bounds.Intersects(gameobject.GetComponent<Renderer>().bounds)) {
                Vector2[] zoneCornersLocal = GetComponent<PolygonCollider2D>().points;
                List<Vector3> zoneCornersWorld = new List<Vector3>();
                foreach (Vector2 v in zoneCornersLocal) {
                    zoneCornersWorld.Add(transform.TransformPoint(v));
                }
                List<Vector2> zoneCornersOfInterest = new List<Vector2>();
                List<int> cornerIndexes = new List<int>();
                for (int i = 0; i < zoneCornersWorld.Count; i++) {
                    RaycastHit2D cornerRaycast = Physics2D.Raycast(zoneCornersWorld[i], transform.position - zoneCornersWorld[i], 0.1f, 1 << LayerMask.NameToLayer("Platform"));
                    if (cornerRaycast.collider == gameobject.GetComponent<PolygonCollider2D>()) {
                        zoneCornersOfInterest.Add(zoneCornersWorld[i]);
                        cornerIndexes.Add(i);
                    }
                }
                if (cornerIndexes.Count > 1) {
                    if (cornerIndexes[1] - cornerIndexes[0] > 1) {
                        zoneCornersOfInterest.Reverse();    
                    }
                }
                // For the objects that are interactable and touching the zone: 
                gameobject.SendMessage("ZoneTrigger", zoneCornersOfInterest);
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
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
                Vector2[] zoneCornersLocal = GetComponent<PolygonCollider2D>().points;
                List<Vector3> zoneCornersWorld = new List<Vector3>();
                foreach (Vector2 v in zoneCornersLocal) {
                    zoneCornersWorld.Add(transform.TransformPoint(v));
                }
                List<Vector2> zoneCornersOfInterest = new List<Vector2>();
                foreach (Vector3 v in zoneCornersWorld) {
                    RaycastHit2D cornerRaycast = Physics2D.Raycast(v, transform.position - v, 0.1f, 1 << LayerMask.NameToLayer("Platform"));
                    if (cornerRaycast.collider == gameobject.GetComponent<PolygonCollider2D>()) {
                        zoneCornersOfInterest.Add(v);
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
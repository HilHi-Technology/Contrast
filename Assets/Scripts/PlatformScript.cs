using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public LayerMask mask;
    public GameObject SubColliderPrefab;
    private List<GameObject> subColliders = new List<GameObject>();

	void ZoneTrigger(List<Vector2> zoneCornersOfInterest) {
        Debug.Log("Triggered");
        // Acquire the vertices from the platforms.
		PolygonCollider2D collider2d = GetComponent<PolygonCollider2D> ();
        collider2d.enabled = false;
		Vector2[] vertices = collider2d.points;
        List<Vector2> worldVertices = new List<Vector2>();
        foreach (Vector2 v in vertices) {
            // Transform the platform's vertices from local to global points.
            Vector2 vector = transform.TransformPoint((Vector3)v);
            worldVertices.Add(transform.TransformPoint(v));
        }
		int zoneLayer = LayerMask.NameToLayer("Zone");
        // Some maths to create custom hitbox.
        List<Vector2> pointsOfInterest = new List<Vector2>();
        List<Vector2> verticesOfInterest = new List<Vector2>();
        List<Vector2> intersectionsOfInterest = new List<Vector2>();
        for (int i = 0; i < 4; i++) {
            int previousIndex = i == 0 ? 3 : i - 1;
            int nextIndex = i == 3 ? 0 : i + 1;
            RaycastHit2D raycast1 = Physics2D.Raycast(worldVertices[i], worldVertices[previousIndex] - worldVertices[i], Mathf.Infinity, mask);
            RaycastHit2D raycast2 = Physics2D.Raycast(worldVertices[i], worldVertices[nextIndex] - worldVertices[i], Mathf.Infinity, mask);
            if (!((raycast1.fraction == 0 && raycast1.collider != null) && (raycast2.fraction == 0 && raycast2.collider != null))) {
                if (raycast1.collider != null) {
                    Vector2 point = raycast1.point;
                    pointsOfInterest.Add(point);
                    intersectionsOfInterest.Add(point);
                }
                Vector2 vertex = worldVertices[i];
                pointsOfInterest.Add(vertex);
                verticesOfInterest.Add(vertex);
                if (raycast2.collider != null) {
                    Vector2 point = raycast2.point;
                    pointsOfInterest.Add(point);
                    intersectionsOfInterest.Add(point);
                }
            }
        }

        if (pointsOfInterest.Count == 8) {
            // Cases where the zone would split the platform into 2.
            GameObject subCollider1 = Instantiate(SubColliderPrefab) as GameObject;
            subCollider1.transform.parent = gameObject.transform;
            subColliders.Add(subCollider1);
            GameObject subCollider2 = Instantiate(SubColliderPrefab) as GameObject;
            subCollider2.transform.parent = gameObject.transform;
            subColliders.Add(subCollider2);
            List<Vector2> colliderPoints1 = new List<Vector2>();
            List<Vector2> colliderPoints2 = new List<Vector2>();
            int i = 0;
            while (colliderPoints1.Count < 4) {
                int nextIndex = (i == pointsOfInterest.Count - 1 ? 0 : i + 1);
                colliderPoints1.Add(pointsOfInterest[i]);
                if (intersectionsOfInterest.Contains(pointsOfInterest[i])) {
                    if (intersectionsOfInterest.Contains(pointsOfInterest[nextIndex])) {
                        int targetIndex = i + 4;
                        while (colliderPoints2.Count < 4)  {
                            i++;
                            colliderPoints2.Add(pointsOfInterest[i]);
                        }
                    }
                }
                i++;
            }
            PolygonCollider2D polyCollider1 = subCollider1.GetComponent<PolygonCollider2D>();
            polyCollider1.points = colliderPoints1.ToArray();
            PolygonCollider2D polyCollider2 = subCollider2.GetComponent<PolygonCollider2D>();
            polyCollider2.points = colliderPoints2.ToArray();

        } else {
            GameObject subCollider = Instantiate(SubColliderPrefab) as GameObject;
            subCollider.transform.parent = gameObject.transform;
            subColliders.Add(subCollider);
            PolygonCollider2D polyCollider = subCollider.GetComponent<PolygonCollider2D>();
            for (int i = 1; i < pointsOfInterest.Count; i++) {
                if (intersectionsOfInterest.Contains(pointsOfInterest[i])) {
                    foreach (Vector2 v in zoneCornersOfInterest) {
                        pointsOfInterest.Insert(i + 1, v);
                        print("ping " + i);
                    }
                    break;
                }
                print("ping");
            }
            foreach(Vector2 v in pointsOfInterest) {
                print(v.x + " " + v.y);
            }
            polyCollider.points = pointsOfInterest.ToArray();

        }
    }

    void ZoneReset()
    {
        PolygonCollider2D collider2d = GetComponent<PolygonCollider2D>();
        collider2d.enabled = true;
        foreach (GameObject obj in subColliders)
        {
            Destroy(obj);
        }
    }
}

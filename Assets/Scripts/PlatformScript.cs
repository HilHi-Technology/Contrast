using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public LayerMask mask;
    public GameObject SubColliderPrefab;

	void ZoneTrigger(GameObject zone) {
        Debug.Log("Triggered");
		PolygonCollider2D collider2d = GetComponent<PolygonCollider2D> ();
		Vector2[] vertexes = collider2d.points;
        List<Vector2> worldVertexes = new List<Vector2>();
        foreach (Vector2 v in vertexes)
        {
            Vector2 vector = transform.TransformVector(v);
            worldVertexes.Add(transform.TransformVector(v));
        }
		int zoneLayer = LayerMask.NameToLayer("Zone");
        List<RaycastHit2D> raycasts = new List<RaycastHit2D>();
        raycasts.Add(Physics2D.Raycast(worldVertexes[0], worldVertexes[1] - worldVertexes[0], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[1], worldVertexes[2] - worldVertexes[1], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[2], worldVertexes[3] - worldVertexes[2], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[3], worldVertexes[0] - worldVertexes[3], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[0], worldVertexes[3] - worldVertexes[0], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[1], worldVertexes[0] - worldVertexes[1], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[2], worldVertexes[1] - worldVertexes[2], Mathf.Infinity, mask));
        raycasts.Add(Physics2D.Raycast(worldVertexes[3], worldVertexes[2] - worldVertexes[3], Mathf.Infinity, mask));
        int intersectionPoints = 0;
        List<RaycastHit2D> intersectionHits = new List<RaycastHit2D>();
        foreach (RaycastHit2D r in raycasts)
        {
            if (r.collider != null)
            {
                if (r.fraction != 0)
                {
                    intersectionHits.Add(r);
                    print(r.point);
                    intersectionPoints++;
                }
            }
        }
        print(intersectionPoints);
        collider2d.enabled = false;
        if (intersectionPoints == 4)
        {
            GameObject subCollider1 = Instantiate(SubColliderPrefab) as GameObject;
            subCollider1.transform.parent = gameObject.transform;
            GameObject subCollider2 = Instantiate(SubColliderPrefab) as GameObject;
            subCollider2.transform.parent = gameObject.transform;
        } else if (intersectionPoints == 2)
        {
            GameObject subCollider = Instantiate(SubColliderPrefab) as GameObject;
            subCollider.transform.parent = gameObject.transform;

        }
    }

}

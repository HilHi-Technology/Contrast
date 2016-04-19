using UnityEngine;

public class ZoneCameraFixScript : MonoBehaviour {

    private Camera zoneCamera;
    public Transform quad;

	// Use this for initialization
	void Start () {
	    zoneCamera = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
	    zoneCamera.orthographicSize = transform.parent.localScale.x / 2;
	}
}

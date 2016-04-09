using UnityEngine;
using System.Collections;

public class ZoneCameraFixScript : MonoBehaviour {

    private Camera camera;
    public Transform quad;
    
	// Use this for initialization
	void Start () {
	    camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
	    camera.orthographicSize = transform.parent.localScale.x / 2;
	}
}

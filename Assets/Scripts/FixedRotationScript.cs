using UnityEngine;
using System.Collections;

public class FixedRotationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    transform.eulerAngles = Vector3.zero;
	}
}

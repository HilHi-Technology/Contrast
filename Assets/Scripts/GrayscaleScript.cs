using UnityEngine;
using System.Collections;

public class GrayscaleScript : MonoBehaviour {
    public float saturation;
    private Renderer renderer;
	// Use this for initialization
	void Start () {
	    renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    renderer.material.SetFloat("_EffectAmount", saturation);
	}
}

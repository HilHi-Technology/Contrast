using UnityEngine;
using System.Collections;

public class SpriteControlScript : MonoBehaviour {
    public float saturation;
    public bool enableTiling;
    private Renderer renderer;
	// Use this for initialization
	void Start () {
	    renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    renderer.material.SetFloat("_EffectAmount", saturation);
        Vector3 scale = transform.lossyScale;
        if (enableTiling) {
            renderer.material.SetFloat("RepeatX", scale.x);
            renderer.material.SetFloat("RepeatY", scale.y);
        }
	}
}

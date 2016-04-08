using UnityEngine;
using System.Collections;

public class SpriteControlScript : MonoBehaviour {
    public float saturation;
    public float RepeatX = 1;
    public float RepeatY = 1;
    private Renderer renderer;
	// Use this for initialization
	void Start () {
	    renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    renderer.material.SetFloat("_EffectAmount", saturation);
        renderer.material.SetFloat("RepeatX", RepeatX);
        renderer.material.SetFloat("RepeatY", RepeatY);
	}
}

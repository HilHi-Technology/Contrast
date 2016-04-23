using UnityEngine;

public class SpriteControlScript : MonoBehaviour {
    public float saturation;
    public bool enableTiling;
    private Renderer spriteRenderer;
	// Use this for initialization
	void Start () {
	    spriteRenderer = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update () {
	    spriteRenderer.material.SetFloat("_EffectAmount", saturation);
        Vector3 scale = transform.lossyScale;
        if (enableTiling) {
            spriteRenderer.material.SetFloat("RepeatX", scale.x);
            spriteRenderer.material.SetFloat("RepeatY", scale.y);
        }
	}
}

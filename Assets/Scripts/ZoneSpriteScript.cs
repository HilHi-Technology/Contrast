using UnityEngine;
using System.Collections;

public class ZoneSpriteScript : MonoBehaviour {
    public float shakeRange;
    public GameObject shade;
    private int colorInt = 0;
	// Update is called once per frame
	void Update () {
        shade.transform.localPosition = transform.localPosition * 2;
        float x = Random.value * shakeRange;
        float y = Random.value * shakeRange;
        transform.localPosition = new Vector2(x - shakeRange/2, y - shakeRange/2);
        SpriteRenderer shadeSprite = shade.GetComponent<SpriteRenderer>();
        if (shadeSprite.color != Color.white) {
            shadeSprite.color = Color.white;
        } else {
            if (colorInt == 0) {
                shadeSprite.color = Color.red;
                colorInt++;
            }
            else if (colorInt == 1) {
                shadeSprite.color = Color.green;
                colorInt++;
            }
            else if (colorInt == 2) {
                shadeSprite.color = Color.blue;
                colorInt = 0;
            }
        }
	}
}

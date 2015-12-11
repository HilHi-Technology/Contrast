using UnityEngine;

public class PlatformScript : MonoBehaviour {

	void ZoneTrigger(GameObject zone) {
        Debug.Log("Triggered");
        gameObject.layer = LayerMask.NameToLayer("AltPlatform");
		
    }

}

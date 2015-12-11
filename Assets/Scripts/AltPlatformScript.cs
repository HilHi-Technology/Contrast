using UnityEngine;

public class AltPlatformScript : MonoBehaviour {

	void ZoneTrigger(GameObject zone) {
        Debug.Log("Triggered");
        gameObject.layer = LayerMask.NameToLayer("Platform");
    }

}

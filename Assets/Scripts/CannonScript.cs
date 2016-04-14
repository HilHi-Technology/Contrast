using UnityEngine;

public class CannonScript : MonoBehaviour {

    public float shootSpeed;  // How fast will the cannon shoot.
    public float cannonBallSpeed;  // How fast will the cannonball travel.
    public GameObject shootSpot;  // The spot that the cannonball will appear.

    public GameObject cannonBall;
    private float timer;
    private bool shootReady;


	// Use this for initialization
	void Start () {
	    timer = shootSpeed;
	}

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if(timer < 0){
            shootReady = true;
            timer = shootSpeed;
        }
	    if(shootReady){
            shootReady = false;
            GameObject cannonBallObj = Instantiate(cannonBall, shootSpot.transform.position, Quaternion.identity) as GameObject;
            cannonBallObj.GetComponent<Rigidbody2D>().AddForce(transform.right * -cannonBallSpeed);
            //cannonBallObj.GetComponent<Rigidbody2D>().AddTorque(1000);
        }
	}
}

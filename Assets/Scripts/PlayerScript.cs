using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [System.NonSerialized]
    public bool jump = false;

    public float speed = 5f;
    public float jumpPower = 150f;
    public Transform groundCheck;

    private bool grounded = false;
    public GameObject zone;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform"));

        float h = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded) {
            rb2d.AddForce(Vector2.up * jumpPower);
            jump = false;
        }

        if (Input.GetButtonDown("Fire1")) {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Mathf.Infinity, 1 << LayerMask.NameToLayer("Platform"));
            // This is kind of cancer code so simplify somtimes pls.
            if(raycastHit2D.point != Vector2.zero){
                zone.transform.position = new Vector3(raycastHit2D.point.x, raycastHit2D.point.y, 0);
            } else {
                zone.transform.position = new Vector3(999, 999, 0);
            }            
        }
    }
}

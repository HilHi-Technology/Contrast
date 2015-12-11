using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [HideInInspector]
    public bool jump = false;

    public float speed = 5f;
    public float jumpPower = 150f;
    public Transform groundCheck;

    private bool grounded = false;

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

        //if (Input.GetButtonDown(KeyCode.Mouse0)) {
        //
        //}
    }
}

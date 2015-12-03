using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    [HideInInspector]
    public bool jump = false;

    public float acceleration = 365f;
    public float maxSpeed = 5f;
    public float jumpPower = 150f;
    public Transform groundCheck;

    private bool grounded = false;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(transform.position, groundCheck.position, Color.yellow);
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform"));

        if (Input.GetButtonDown("Jump") && grounded) {
            jump = true;
        }
    }

    void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");

        //if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * acceleration);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (jump) {
            rb2d.AddForce(new Vector2(0f, jumpPower));
            jump = false;
        }
    }
}

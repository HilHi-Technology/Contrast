using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [System.NonSerialized]
    public bool jump = false;

    public float speed = 5f;
    public float jumpPower = 150f;
    public Transform groundCheck;

    private bool grounded = false;
    private bool predicting = false;

    private GameObject instantiatedLine;
    private GameObject instantiatedZone;
    public GameObject zone;
    public GameObject predictionLine;

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

        if (Input.GetButton("Fire1"))
        {
            if (predicting == false)
            {
                instantiatedLine = Instantiate(predictionLine);
                predicting = true;
            }
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Mathf.Infinity, 1 << LayerMask.NameToLayer("Platform"));
            Vector2 target;
            if (raycastHit2D.collider == null)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                target *= 9999999;
            } else
            {
                target = raycastHit2D.point;
            }
            LineRenderer line = instantiatedLine.GetComponent<LineRenderer>();
            line.SetPositions(new Vector3[] {transform.position, target});
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Destroy(instantiatedLine);
            Destroy(instantiatedZone);
            predicting = false;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position, Mathf.Infinity, 1 << LayerMask.NameToLayer("Platform"));
            if (raycastHit2D.collider != null)
            {
                instantiatedZone = Instantiate(zone);
                instantiatedZone.transform.position = raycastHit2D.point;
            }
        }
    }
}

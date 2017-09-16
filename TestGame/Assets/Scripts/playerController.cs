using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpForce;

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    public float fireRate;
    float nextFire = 0f;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();


        facingRight = true;
	}

    // Update is called once per frame
    void Update()
    {
        //check and set the animationa and add force to the character
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpForce));
        }

        if (Input.GetAxis("Fire1") > 0) fireBullet();

    }

       void FixedUpdate () {
        //check for grounded - if not then it is falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalspeed", myRB.velocity.y);


        float move = Input.GetAxis("Horizontal");//GetAxis returns the value between -1 - 0 is left is pressed and 1-0 if right is pressed
        myAnim.SetFloat("speed", Mathf.Abs(move));
       
        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);//increacse the movemet vetor in x direction by the value of move*maxSpeed while along y direction it remains as it is
       
        if (move > 0 && !facingRight)
            flip();
        else if (move < 0 && facingRight)
            flip();
	}

    void flip()
    {
        facingRight = !facingRight;//turns the facing
        Vector3 theScale = transform.localScale;//get the scale , as scale is a 3D parameter Vector3 is used
        theScale.x *= -1;//change the scale value to "-ve"
        transform.localScale = theScale;//apply the new scale
    }

    void fireBullet()
    {
        if(Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            else if (!facingRight)
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
        }
    }
}

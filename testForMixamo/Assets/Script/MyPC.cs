using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]

public class MyPC: MonoBehaviour
{
    Animator myAnim;
    CharacterController myCC;
    Rigidbody myRB;

    [System.Serializable]
    public class Movement
    {
        public float jumpSpeed = 10f;
        public float jumpTime = 1f;
    }

    [SerializeField]
    public Movement move;
    bool jumping;
    bool resetGravity;
    private float gravity;


    // Use this for initialization
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        myCC = GetComponent<CharacterController>();
        myAnim = GetComponent<Animator>();
        setupAnim();
    }



    // Update is called once per frame
    void Update()
    {
        //applyGravity();
        Animate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Animate(float forward, float strafe)
    {
        myAnim.SetFloat("Forward", forward);
        myAnim.SetFloat("Strafe", strafe);
        myAnim.SetBool("isGrounded", myCC.isGrounded);
        myAnim.SetBool("isJumping", jumping);
    }

   /* void applyGravity()
    {
        if (!myCC.isGrounded)
        {
            if (!resetGravity)
            {
                gravity = physics.resetGravity;
                resetGravity = true;
            }
            gravity += physics.gravityModifier * Time.deltaTime;
        }
        else
        {
            gravity = physics.baseGravity;
            resetGravity = false;
        }
        Vector3 _gravityVec = new Vector3();
        if (jumping)
        {
            _gravityVec.y = move.jumpSpeed;
        }
        else
        {
            _gravityVec.y -= gravity;
        }
        myCC.Move(_gravityVec * Time.deltaTime);
    }*/

    public void Jump()
    {
        if (jumping) return;

        Vector3 force = new Vector3(0, -(transform.position.y), 0);
        if (myCC.isGrounded)
        {
            myRB.AddForce(force , ForceMode.Acceleration);
           
        }
    }

    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(move.jumpTime);
        jumping = false;
    }

    void setupAnim()
    {
        Animator[] _anim = GetComponentsInChildren<Animator>();
        if (_anim.Length > 0)
        {
            for (int i = 0; i < _anim.Length; i++)
            {
                Animator _animcurr = _anim[i];
                Avatar _avatar = _animcurr.avatar;

                if (_animcurr != myAnim)
                {
                    myAnim.avatar = _avatar;
                    Destroy(_animcurr);
                }
            }
        }
    }
}

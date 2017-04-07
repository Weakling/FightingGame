using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    public float error;

    private float moveVelocity;
    public float xVelocity, yVelocity;
    public float moveSpeed;
    public bool isCrouched;

    // animation
    private Animator myAnimator;


    private string inputAxisX, inputAxisY, inputAxisA;

    private Rigidbody2D myRigidbody2D;

	void Start ()
    {
        inputAxisX = "HorizontalP1";
        inputAxisY = "VerticalP1";
        inputAxisA = "A1";
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        error = .2f;

    }
	
	void Update ()
    {
        Move();
        SetAnimations();
        
        //xVelocity = 0;
        //yVelocity = 0;
        //myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
	}



    private void Move()
    {
        // set axis inputs
        xVelocity = Input.GetAxisRaw(inputAxisX);
        yVelocity = Input.GetAxisRaw(inputAxisY);

        // is crouched..
        if(yVelocity < -error)
        {
            isCrouched = true;
        }
        else
        {
            isCrouched = false;
        }

        if(isCrouched)
        {
            if (Input.GetButtonDown(inputAxisA))
            {
                Debug.Log("moo");
                myAnimator.SetBool("2A", true);
            }
        }

        // apply movement
        myRigidbody2D.velocity = new Vector2(xVelocity * moveSpeed, myRigidbody2D.velocity.y);
    }

    // set animations
    private void SetAnimations()
    {
        // walking animation
        myAnimator.SetFloat("speed", xVelocity);

        // crouch animation
        myAnimator.SetBool("crouched", isCrouched);
    }

    // animation (go to sitting from idle)
    public void SittingDown()
    {
        myAnimator.SetBool("standingUp", false);
    }

    // animation (go to idle from sitting)
    public void StandingUp()
    {
        myAnimator.SetBool("standingUp", true);
    }

    // animation (exit 2A)
    public void ExitAttack()
    {
        myAnimator.SetBool("2A", false);
    }
}

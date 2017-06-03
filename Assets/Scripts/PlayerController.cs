using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    public float error;

    private bool exitLight;

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
        exitLight = true;

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
            // 2A
            if (Input.GetButtonDown(inputAxisA))
            {
                //if(exitLight)
                {
                    TwoA();
                    //exitLight = false;
                }
                
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
        myAnimator.SetBool("crouching", isCrouched);
    }

    // animation (go to sitting down from idle)
    public void NotStandingUp()
    {
        myAnimator.SetBool("standingUp", false);
        myAnimator.SetBool("crouched", false);
    }

    // animation (go to idle from sitting)
    public void StandingUp()
    {
        myAnimator.SetBool("standingUp", true);
    }

    // animation (go to idle crouch from sitting)
    public void Crouched()
    {
        myAnimator.SetBool("crouched", true);
    }

    public void TwoA()
    {
        myAnimator.SetBool("2A", true);
    }

    // animation (exit 2A)
    public void ExitLightAttack()
    {
        myAnimator.SetBool("2A", false);
        //exitLight = true;
    }

    //float deadzone = 0.25f;
    //Vector2 stickInput = new Vector2(Input.GetAxis(“Horizontal”), Input.GetAxis(“Vertical”));
    //if(stickInput.magnitude<deadzone)
        //stickInput = Vector2.zero;
}

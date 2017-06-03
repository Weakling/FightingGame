using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour {

    // axis names
    public string inputXAxis, inputYAxis;

    // sticks
    public float xInputValue, yInputValue;

    // movement counters
    private bool waitingSideSmash, dashingLeft, dashingRight;
    private int ctrSideSmashRightInput, ctrSideSmashLeftInput, ctrStopMoving;

    // state
    private bool grounded;
    private bool jumped;

    // jump
    public float jumpForce, shortHopForce;

    public float decelerationRate, currentSpeed, runningSpeed, airSpeed, fallSpeed;
    private float appliedGroundSpeed;

    public int weight;

    // animation
    private Animator myAnimator;
    private string stRunning, stDashing, stSpeed;

    private Rigidbody2D myRigidbody2D;
    

    void Awake()
    {
        inputXAxis = "HorizontalP1";
        inputYAxis = "VerticalP1";
        stRunning = "Walking";
        stDashing = "Dashing";
        stSpeed = "Speed";

        myAnimator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    

	void Start ()
    {
        

        grounded = true;

        

    }

    void FixedUpdate()
    {
        xInputValue = Input.GetAxisRaw(inputXAxis);
        yInputValue = Input.GetAxisRaw(inputYAxis);

        


        // moving
        if (xInputValue != 0) //xInputValue > 0)
        {
            // animation
            myAnimator.SetBool(stRunning, true);

            // on ground
            if (grounded)
            {
                // right input
                if (xInputValue > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                // left input
                else if(xInputValue < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                appliedGroundSpeed = runningSpeed;
            }
        }

        else if (xInputValue == 0)
        {
            #region
            // animation
            myAnimator.SetBool(stRunning, false);
            
            // deceleration
            if (appliedGroundSpeed > -0.1f && appliedGroundSpeed < 0.1f)
            {
                appliedGroundSpeed = 0;
            }
            if (appliedGroundSpeed > 0)
            {
                appliedGroundSpeed -= decelerationRate;
            }
            else if (appliedGroundSpeed < 0)
            {
                appliedGroundSpeed += decelerationRate;
            }
            #endregion
            
        }
        myAnimator.speed = Mathf.Abs(xInputValue * appliedGroundSpeed);
        myRigidbody2D.velocity = new Vector2(appliedGroundSpeed * xInputValue, myRigidbody2D.velocity.y);

        /*


        ctrStopMoving = 0;
        // not dashing
        if(!dashingRight)
        {
            #region
            //dashingLeft = false;
            waitingSideSmash = true;
            // waited 3 frames
            if (ctrSideSmashRightInput == 3)
            {
                //ctrSideSmashRightInput = 0;
                dashingRight = true;
            }
            // incrementing
            else
            {
                ctrSideSmashRightInput++;
                print(ctrSideSmashRightInput);
            }
            #endregion
        }
        // is dashing right
        else
        {
            if(xInputValue > 0)
            {
                appliedGroundSpeed = runningSpeed;
            }
            else if(xInputValue < 0)
            {
                appliedGroundSpeed = -runningSpeed;
            }
        }*/



        /*if (xInputValue < 0)
        {
            #region
            // not dashing right
            if (!dashingLeft)
            {
                #region
                dashingRight = false;
                waitingSideSmash = true;
                // waited 3 frames
                if (ctrSideSmashLeftInput == 3)
                {
                    ctrSideSmashLeftInput = 0;
                    dashingLeft = true;
                }
                // incrementing
                else
                {
                    ctrSideSmashLeftInput++;
                    print(ctrSideSmashLeftInput);
                }
                #endregion
            }
            // is dashing right
            else
            {
                appliedGroundSpeed = -runningSpeed;
            }
            #endregion
        }
        else
        {
            ctrSideSmashLeftInput = 0;
        }*/

        // no input



    }



    void Update ()
    {

        if (Input.GetButtonDown("AP1"))
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
        }
        /*if(yInputValue > 0.1f && !jumped)
        {
            myRigidbody2D.velocity = new Vector2(xInputValue * moveSpeed, myRigidbody2D.velocity.y);
        }*/
        MovementCalculation();
        //myRigidbody2D.velocity = new Vector2(10, myRigidbody2D.velocity.y);
        
        //Vector2 xForce = new Vector2(xInputValue * moveSpeed, myRigidbody2D.velocity.y);
        //myRigidbody2D.AddForce(xForce);
	}

    void MovementCalculation()
    {
        // accelerate
        
        
        // left
        /*else if (xInputValue < 0)
        {
            currentSpeed -= accelerationRate;
            if (currentSpeed < runningSpeed * xInputValue)
            {
                currentSpeed += accelerationRate;
            }
        }*/
        

    }




}

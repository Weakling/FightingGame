using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    public float error;

    private float moveVelocity;
    public float xVelocity, yVelocity;
    public float moveSpeed;

    // animation
    private Animator myAnimator;


    private string inputAxisX, inputAxisY;

    private Rigidbody2D myRigidbody2D;

	void Start ()
    {
        inputAxisX = "HorizontalP1";
        inputAxisY = "VerticalP1";
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        error = .2f;

    }
	
	void Update ()
    {
        Move();

        myAnimator.SetFloat("speed", xVelocity);
        //xVelocity = 0;
        //yVelocity = 0;
        //myRigidbody2D.velocity = new Vector2(0f, myRigidbody2D.velocity.y);
	}



    private void Move()
    {
        xVelocity = Input.GetAxisRaw(inputAxisX);
        yVelocity = Input.GetAxisRaw(inputAxisY);

        myRigidbody2D.velocity = new Vector2(xVelocity * moveSpeed, myRigidbody2D.velocity.y);
        // right..
        /*if(xVelocity > error)
        {
            myRigidbody2D.velocity = new Vector2(moveSpeed, myRigidbody2D.velocity.y);
        }
        // left..
        if (xVelocity < -error)
        {
            myRigidbody2D.velocity = new Vector2(-moveSpeed, myRigidbody2D.velocity.y);
        }*/
    }
}

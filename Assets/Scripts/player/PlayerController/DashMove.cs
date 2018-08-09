using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour {

    //the time the dash can be used
    public float startDashTime;

    //the speed of the dash
    public float dashSpeed;

    //setting the rigid body 2d
    private Rigidbody2D rb;

    //how long the dash last
    private float dashTime;

    //determines the direction of the dash
    private int direction;

	// Use this for initialization
	void Start () {
		
        //rb get the component rigidbidy2d
        rb = GetComponent<Rigidbody2D>();

        //the beginning the start of the dash becomes how long the dash will be
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {

        //checks if the player is not dashing
        if(direction == 0)
        {
            //checks the direction the player will dash
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;

            }else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;

            }else if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
        }else
        {
            //if the dash timer is 0, then direction is bac to 0 and the player can  dash again.
            if(dashTime <= 0)
            {
                direction = 0;
                //it will subtract the dash time by the computer's processing power 

                //reset the dash time
                dashTime = startDashTime;

                rb.velocity = Vector2.zero;
            }else
            {
                dashTime -= Time.deltaTime;

                //determines the dashtime of each dash
                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;

                }else if(direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;

                }else if(direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;

                }else if(direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
            }
        }
	}
}

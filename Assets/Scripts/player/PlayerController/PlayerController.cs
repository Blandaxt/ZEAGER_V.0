using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //setting up my wintext variable
    public Text winText;

    //float is non-whole numbers like decimal numbers
    public float moveSpeed;

    //sample speed
    public float speed;

    //variable that is created for the count variable so it can be displayed
    public Text countText;

    //how long it takes to attack 
    public float attackTime;

    //for the player to attack
    private bool attacking; 

    //a reference to the animator
    private Animator animate;

    //Player moving variable
    private bool playerMoving;

    //for player face direction
    private Vector2 lastMove;

    //holds a pointer to the RigidBody2D component
    private Rigidbody2D rb2d;

    //counter to see how much items you have picked up
    private int count;

    //the time it takes to attack for the player to be subtracted so the player can atack again
    private float attackTimeCounter;

	// Use this for initialization of the script
	void Start () 
    {
        //stores the pointer to the RigidBody2D component
        rb2d = GetComponent<Rigidbody2D>();

        //logging the rigidbody2d component
        //Debug.Log(rb2d); 

        //a variable that holds the animator
        animate = GetComponent<Animator>();

        //loging in the console the animate variable
        //Debug.Log(animate);

        //count is set to 0
        count = 0;

        //wintext is set to an empty string
        winText.text = "";

        //running the set count text function
        SetCountText();
	}

    void Update () 
    {
        //When the player is not attacking, the player can be allowed to move
        if (!attacking)
        {
            //Edge case if i wanted to use the addforce method for the x 
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            }

            //Edge case if i wanted to use the addforce method for the x 
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            }

            //connects the editor animator lastmove_x to the lastmove variable
            animate.SetFloat("LastMoveX", lastMove.x);

            //connects lastmove_y on the editor to the last move variable 
            animate.SetFloat("LastMoveY", lastMove.y);

            //The player can attack on key down spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attackTimeCounter = attackTime;

                attacking = true;

                rb2d.velocity = Vector2.zero;
                animate.SetBool("Attack", true);
            }
        }

        //attackTimeCounter will be subtracted every second
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        //if  counter is not yet over, you cannot attack.
        if(attackTimeCounter < 0)
        {
            attacking = false;

            animate.SetBool("Attack", false);
        }
    }

  //....................................................................................void update 
    //....................................................................................void update   
    //....................................................................................void update   


	// Update is called once per frame 
	void FixedUpdate ()
    {
        
        playerMoving = false;

        //When the player is not attacking, the player can be allowed to move
        if (!attacking)
        {



            //Unity from 2015
            //notes: Movement for horizontal meaning side to side
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                //gets the movement speed times the deltatime for the x axis times delta time
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));

                //player moving set to true
                playerMoving = true;

                //player faces that side to side direction after moving that direction the value is stored in the last move variable
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

                //Debug.Log("X-axis: " + lastMove);
            }

            //notes: PlayerMovement for vertical meaning up and down
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //Gets the movement for the y axis speed times speed and delta time so player can move at a consistant pace no matter the frameRate
                transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

                //playerMoving moving set to true when the if function fires
                playerMoving = true;

                //player faces that up or down direction after going that direction
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

                //Debug.Log("Y-Axis: " + lastMove);

            }


            //Unity from 2017
            //moveSpeed Horizontal
            float moveHorizontal = Input.GetAxis("Horizontal");

            //moveSpeed Vertical
            float moveVertical = Input.GetAxis("Vertical");

            //uses the two (up) Vertical and (down) Horizontal variables to store them in the vector 2 movement variable
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            //calls the add force function on the RigidBody2d suplying movement times speed to move
            rb2d.AddForce(movement * speed);
            //Did not use this method because it adds force and replicates a constant movement in the direction that the player choses. This creates a phantom drag that keeps the playerObject moving until there is enough force in the opposite direction to move the player to another position. Not fit for 2d, unless it is attached to a special object like a motorbike that the player can use. 

            //for the animation for the x axis left and right 
            animate.SetFloat("Move_X", Input.GetAxisRaw("Horizontal"));

            //for the animation for the y axis up and down
            animate.SetFloat("Move_Y", Input.GetAxisRaw("Vertical"));

            //attaches the player moving variable to the string player
            animate.SetBool("PlayerMoving", playerMoving);

            //connects the editor animator lastmove_x to the lastmove variable
            animate.SetFloat("LastMoveX", lastMove.x);

            //connects lastmove_y on the editor to the last move variable 
            animate.SetFloat("LastMoveY", lastMove.y);

        }

	}

     //....................................................................................Fixed void update  
    //....................................................................................Fixed void update  
    //....................................................................................Fixed void update  
    //....................................................................................Fixed void update  

    void Lateupdate()
    {
        //player moving is always false when idle
        playerMoving = false;

        //connects the editor animator lastmove_x to the lastmove variable
        animate.SetFloat("LastMoveX", lastMove.x);

        //connects lastmove_y on the editor to the last move variable 
        animate.SetFloat("LastMoveY", lastMove.y);

        //Debug.Log(lastMove.y);

        //Debug.Log(lastMove.x);
    }

    //....................................................................................Late void update  
    //....................................................................................Late void update  
    //....................................................................................Late void update  


    //a way for the player game object can detect the other game object that the player will want to pick up
    void OnTriggerEnter2D (Collider2D other)
    {
        //if the game object has a tag of pick up, this will happen
        if(other.gameObject.CompareTag ("PickUp")) 
        {
            //the object that the payer encounters will be set to false
            other.gameObject.SetActive(false);

            //count increments by 1 every time a rigid body collider of PickUp is encountered
            count = count + 1;

            //running the function SetCountText
            SetCountText();
        }
    }

    //function for the count text
    void SetCountText ()
    {
        //count is set to string then combined with the string count 
        countText.text = "Gold: " + count.ToString();

        //setting up win conditions
        if( count >= 31)
        {
            winText.text = "YOU ARE THE WINNER!";
        }
    }
}

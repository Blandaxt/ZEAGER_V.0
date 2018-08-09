using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class slimeController : MonoBehaviour {

    //enemy movement
    public float moveSpeed;

    //timebetween each move
    public float timeBetweenMove;

    //the time to move
    public float timeToMove;

    //respawning the player
    public float waitToReload;

    //reloading set to true to activate
    private bool reloading;

    //Touch check if false or true
    private bool moving;

    //the  counter that will cycle between move and send that counter number back
    private float timeBetweenmoveCounter;

    //Time to counter  for time to move to set to
    private float timeToMoveCounter;

    //Rigidbody body manipulation 
    private Rigidbody2D myRigidbody;

    //private Vector3 moveDirection
    private Vector3 moveDirection;

    //sets the player as the game object
    private GameObject thePlayer;

	// Use this for initialization
	void Start () {

        myRigidbody = GetComponent<Rigidbody2D>();

        //alternate
        //timeBetweenmoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenmoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(moving)
        {
            timeToMoveCounter -= Time.deltaTime;

            //moveSpeed direction
            myRigidbody.velocity = moveDirection;

            if(timeToMoveCounter < 0f)
            {
                moving = false;

                //timeBetweenmoveCounter = timeBetweenMove;


                timeBetweenmoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

            }
            
        }else
        {
            //Time between move is sunstracted by device time
            timeBetweenmoveCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenmoveCounter <0f)
            {
                moving = true;

                //sets the time to move
                //timeToMoveCounter = timeToMove;

                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);

                //randomly chooses a direction
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1, 1f) * moveSpeed, 0f);
            }
        }

        if(reloading)
        {
            //counting down the time to reload
            waitToReload -= Time.deltaTime;

            if(waitToReload <0)
            {
                //reloading the level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

                //reactivating the player
                thePlayer.SetActive(true);
            }
        }
	}

	//publi void HurtPlayer -= damageToGive;

    //When two objects with a collider colides something will happen
	 void OnCollisionEnter2D(Collision2D other)
	{
        //if the player collides, this will happen
        if(other.gameObject.name == "Player")	
        {
            //Player object becomes inactive
            //other.gameObject.SetActive(false);

            reloading = true;
            thePlayer = other.gameObject;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour {

    //speed variable for enemy
    public float speed;

    //stopping distance controls in editor
    public float stoppingDistance;

    //when the enemy will stop following the player
    public float followDistance;

    //measures when the enemy object should back away from the object
    public float retreatDistance;

    //Where the enemy should go after stopping to follow
    public Transform concentrationPoint;

    ////enemy attack start time when the enemy attacks
    //public float startTimeBetweenShots;

    ////enemy time between attacks
    //private float timeBetweenShots;



    //private variable to target the player
    private Transform target;

	// Use this for initialization
	void Start () {

        //RenderTargetSetup the object with the tag player and the transform (movement) information location of that object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        concentrationPoint = GameObject.FindGameObjectWithTag("Hive").GetComponent<Transform>(); 
		
	}
	
	// Update is called once per frame
	void Update () {

        //if the distance between the player and the enemy is greater than 3, it will continue to follow the player. Else, it will not without even having to state that.
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {

            //moves the enemies position towards the player's position(target) at the speed time delta time
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            //if the position of the enemy is less than the sopping distance and the position of the enemy is greater than the retreating distance, then the enemy will stay in it's position
        }else if(Vector2.Distance(transform.position, target.position) < stoppingDistance && Vector2.Distance(transform.position, target.position) > retreatDistance)
        {
            //the enemy will stay in it's 
            transform.position = this.transform.position;

        }else if(Vector2.Distance(transform.position, target.position) < retreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }

        //if the player 
        if (Vector2.Distance(transform.position, target.position) > followDistance)
        {

            //moves the enemies position towards the concentration position(point) at the speed time delta time
            transform.position = Vector2.MoveTowards(transform.position, concentrationPoint.position, speed * Time.deltaTime);
        }


		
	}
}

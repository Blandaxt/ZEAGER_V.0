using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAttack : MonoBehaviour {

    ////damage the player wll receive
    //public int damageGiven;

    //speed of the object 
    public float speed;

    //enemy attack start time when the enemy attacks
    public float startTimeBetweenShots;

    //enemy time between attacks
    private float timeBetweenShots;

    //the public variable where i can set my projectile
    public GameObject projectile;

    //private variable to target the player
    private Transform target;


	// Use this for initialization
	void Start () {

        timeBetweenShots = startTimeBetweenShots;

        //RenderTargetSetup the object with the tag player and the transform (movement) information location of that object
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		
	}
	
	// Update is called once per frame
	void Update () {

        //moves the enemies position towards the player's position(target) at the speed time delta time
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		//if this variable is less than or equal to 0
        if(timeBetweenShots < 0)
        {
            //then this object will spawn to move towards the player every amount of seconds we set
            Instantiate(projectile, transform.position, Quaternion.identity);
            //this instantiate not only creates the object, but it also creates no rotation for the Quaternion.identity

            //to set the amount of shots shot per the amount of time passed
            timeBetweenShots = startTimeBetweenShots;
            
        }else{
            //else the time between shots variable will be subtracted by the computers proessing power
            timeBetweenShots -= Time.deltaTime;
        }
	}

    //When two objects with a collider colides something will happen
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    //if the player collides, this will happen
    //     if(other.gameObject.name == "Player")    
    //     {
    //        other.gameObject.GetComponent<PlayerHealthManager>().FlyingEnemyAttack(damageGiven);
    //         //Player object becomes inactive
    //         //other.gameObject.SetActive(false);

    //         //reloading = true;
    //         //thePlayer = other.gameObject;
    //     }
    //}
}

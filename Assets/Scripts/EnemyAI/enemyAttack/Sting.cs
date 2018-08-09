using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sting : MonoBehaviour {

    //speed of the projectile
    public float speed;

    //targeting the player's location
    private Transform player;

    //targeting the player
    private Vector2 target;

	// Use this for initialization
	void Start () {

        //To target the player's tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //targeting the  and y coordinates of the player's last location meaning if the player moves, it willl still go towards that last location
        target = new Vector2(player.position.x, player.position.y);
	}
	
	// Update is called once per frame
	void Update () {

        //move towards the player for every frame
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if the projectile has reached the last location the player's location, then it is destroyed with the destroy projectile function
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            //target += ;
            
            //calling the function
            DestroyProjectile();
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.CompareTag("Player"))
        {
            DestroyProjectile();
        }
	}

	//the method to remove the projectile after it has reached it's destination
	void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

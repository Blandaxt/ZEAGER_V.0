using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject hitEffect;

    //Health for the enemy
    public int health;

    //speed of the enemy
    public float speed;

    //a private animator variable that handles the enemie's animation
    private Animator animate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void TakeDamage(int damage) 
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        //damage - health
        health -= damage;

        Debug.Log("Damage Taken: " + health);
    }
}

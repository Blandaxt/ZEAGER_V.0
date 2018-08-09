using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    //damage the player wll receive
    public int damageGiven;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //When two objects with a collider colides something will happen
    void OnCollisionEnter2D(Collision2D other)
    {
        //if the player collides, this will happen
         if(other.gameObject.name == "Player")    
         {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageGiven);
             //Player object becomes inactive
             //other.gameObject.SetActive(false);

             //reloading = true;
             //thePlayer = other.gameObject;
         }
    }
}

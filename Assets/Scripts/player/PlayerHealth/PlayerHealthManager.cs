using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

    //Player's maximum health
    public int playerMaxHealth;

    //player's current health
    public int playerCurrentHealth;


	// Use this for initialization
	void Start () {

        //player's starting health
        playerCurrentHealth = playerMaxHealth;


		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(playerCurrentHealth <= 0)
        {
            //set's the player inactive after the payer have reached 0 health
            gameObject.SetActive(false);

        }
	}

    //damage the player will take
    public void HurtPlayer(int damageGiven)
    {
        playerCurrentHealth -= damageGiven; 
    }

    //way  for player to gain back health
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    //public void FlyingEnemyAttack(int damageGiven)
    //{
    //    playerCurrentHealth -= damageGiven;
    //}
}

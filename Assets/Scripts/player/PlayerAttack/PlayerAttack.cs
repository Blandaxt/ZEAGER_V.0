using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    
    //sets the amount of damage being subtracted
    public int damage;

    //any object with this layermask of eneies will getdamaged
    public LayerMask whatIsEnemies;

    //determines the circles rendering position and where you will attack
    public Transform attackPos;

    //this determines the circle's range
    public float attackRange;

    //when the player is going to attack
    public float startTimeBetweenAttack;
    
    //Time between each attack
    private float timeBetweenAttack;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		//if the time between each attack is less than or equal to 0
        if(timeBetweenAttack <= 0)
        {
            //if player hits space, this if statement becomes true
            if(Input.GetKey(KeyCode.Space)) 
            {
                
                //this function line determines the player's attack position, the attack's range and what the player can attack
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

                //a for loop to hit all enemies withing the circle's range
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    //takes the first enemy in the array and using the script component to pass in the damage method from that script
                    enemiesToDamage[i].GetComponent<EnemyAI>().TakeDamage(damage);
                }
            }

            //after each attak and the time between attack is fufilled, you can attack again
            timeBetweenAttack = startTimeBetweenAttack;

        }else{
            //the time between each attack is subtracted by the delta time processing of the device
            timeBetweenAttack -= Time.deltaTime;
        }
	}

    //A method for our player's weapon attack area
	private void OnDrawGizmosSelected()
	{
        //gizmos color will be red to help visualize the range and shape of the player's attack.
        Gizmos.color = Color.red;

        //creates a wireframe of the object that will collide to form the attack
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}

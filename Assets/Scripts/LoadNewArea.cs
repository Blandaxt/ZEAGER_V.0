using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {
    
    //variable that will hold the reference the next scene
    public string nextLevel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //method for loading the next scene upon collision of coliders
	void onTriggerEnter2D (Collider2D other)
    {
        //if the player encounters this object
        if(other.gameObject.name == "Player")
        {
            //this scene will load
            SceneManager.LoadScene (nextLevel);
        }

    }
	//SceneManager.LoadScene
}

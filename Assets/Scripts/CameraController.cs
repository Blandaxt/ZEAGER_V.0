using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    //so the camera can follow whatever we target
    public GameObject followTarget;

    public float moveSpeed;

    //async way the camera can follow the player using the players position
    private Vector3 targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame similar to a for loop in javascript
	void Update () 
    {
        //setting the player's transform to this variable
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

        //3 vectors that is goes through. 1st vector is where the camera is, second vector is where the player is, and 3rd vector is the amount of movement the camera is allowed per frame. 
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}

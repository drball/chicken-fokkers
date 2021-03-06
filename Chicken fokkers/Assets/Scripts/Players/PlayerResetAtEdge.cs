﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetAtEdge : MonoBehaviour {

    // public PlayerController PlayerController;
    public Camera cam;
    private float buffer = 1f;
    public static float leftConstraint;
    public static float rightConstraint;
    public GameController GameController;

    void Awake(){
    	GameController = GameObject.Find("SceneController").GetComponent<GameController>();
		cam = GameController.cam;
		
		//--set the screen constraints
		leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0)).x;
        Debug.Log("set cam on playerresetatedge script");
    }

	void FixedUpdate () {

		//--move back onto screen when off the edge
		if (transform.position.x < leftConstraint - buffer) {
			transform.position = new Vector3 (rightConstraint + buffer, transform.position.y, transform.position.z);
		}

		if (transform.position.x > rightConstraint + buffer) {
			transform.position = new Vector3 (leftConstraint - buffer, transform.position.y, transform.position.z);
		}
	}	
}

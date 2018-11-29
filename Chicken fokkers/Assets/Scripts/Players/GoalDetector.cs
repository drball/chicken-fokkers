// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour {

	public PlayerController PlayerController;
	public GameControllerStory GameController;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		if(PlayerController.alive){
	        if (other.name == "Goal"){
				Debug.Log("goal!!!!!");
				GameController.ReachedGoal();

			}
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool alive = true;

	public int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Die(){
		//--trigger a death animation
		Destroy(gameObject);
		Debug.Log(gameObject.name +" is dead");

		//--show the scoreboard - or start another round
	}

	public void ResetScore(){
		score = 0;
	}
}

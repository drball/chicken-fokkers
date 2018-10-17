using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--used for adding a force to instantiated ragdoll when hit

public class AddImpulseForce : MonoBehaviour {

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		
	}
	
	public void AddForce(Vector2 forceAmt){
		rb.AddForce(forceAmt, ForceMode2D.Impulse);
	}
}
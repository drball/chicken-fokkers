using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialForce : MonoBehaviour {

	private Rigidbody2D rb;
	public Vector2 force;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(force, ForceMode2D.Impulse);
		Debug.Log("add initial force");
	}
	
}

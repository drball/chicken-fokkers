using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour {

	public Rigidbody2D rb;
	public float speed = 10f;
	public BoxCollider activateCollider;

	// Use this for initialization
	void Start () {
		rb.AddForce(transform.right * speed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

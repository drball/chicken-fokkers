using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f; //--force
    public float upSpeed = 1f; //--force
    public bool alive = true;
    public bool movingUp = false;
    public float defaultUpForce = 1;
    private Rigidbody2D rb;
    public Renderer rend;
    public TouchControls TouchControls;
    public enum MovementDirections {Right = 0, Left = 1} 
    public MovementDirections MovementDirection= MovementDirections.Right & MovementDirections.Left;

    private float upForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {

		if(alive){


			movingUp = false;


			if(MovementDirection == MovementDirections.Left){

				if(TouchControls.RightPressed) {
					movingUp = true;
					upForce = defaultUpForce + upSpeed;
				} else {
					upForce = defaultUpForce;
				}

				speed = -speed;

			} else {

				if(TouchControls.LeftPressed) {
					movingUp = true;
					upForce = defaultUpForce + upSpeed;
				} else {
					upForce = defaultUpForce;
				}
				
			}

			Debug.Log("add force. speed = "+speed+", up = "+upForce);
			rb.AddForce(new Vector2(speed, upForce));

			Vector2 moveDirection = rb.velocity;
         	if (moveDirection != Vector2.zero) {
            	float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            	transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         	}
			
		}
	}
}

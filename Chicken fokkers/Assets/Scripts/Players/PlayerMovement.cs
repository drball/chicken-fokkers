using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1f; //--force
    public float upSpeed = 1f; //--force
    public bool movingUp = false;
    public float defaultUpForce = 1;
    private Rigidbody2D rb;
    public Renderer rend;
    public TouchControls TouchControls;
    public PlayerController PlayerController;
    public enum MovementDirections {Right = 0, Left = 1} 
    public MovementDirections MovementDirection= MovementDirections.Right & MovementDirections.Left;
    private float startPosX; 
    private float startPosY = 3f; 
    public Camera cam;
    private float buffer = 1f;
    private int dir = 1;
    public bool autoPilot = true;

    private float leftConstraint;
    private float rightConstraint;

    private float upForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		leftConstraint = cam.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 0)).x;
        rightConstraint = cam.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 0)).x;

	}

	public void MoveToStartPos(){

		Debug.Log("Move"+gameObject.name+" to start pos");

		//--start positions
        if(MovementDirection == MovementDirections.Left){
			startPosX = rightConstraint;
			transform.position = new Vector3(startPosX,startPosY,0);
			dir = -1;
    	} else {
    		startPosX = leftConstraint;
    		transform.position = new Vector3(startPosX,startPosY,0);
    	}

    	//--cancel their velocity
		rb.velocity = Vector2.zero;

		gameObject.transform.rotation = Quaternion.identity;
	}
	

	void FixedUpdate () {

		upForce = defaultUpForce;
		movingUp = false;

		if(PlayerController.alive){

			if(MovementDirection == MovementDirections.Left){
				//--moving right to left

				if(TouchControls.RightPressed) {
					movingUp = true;
					upForce = defaultUpForce + upSpeed;
				} 

			} else {
				//--moving left to right
				if(TouchControls.LeftPressed) {
					movingUp = true;
					upForce = defaultUpForce + upSpeed;
				} 
			}
			
		}

		//--check if on autopilot - if not, fall
		if(autoPilot){
			upForce = defaultUpForce + upSpeed/1.85f;
		} 

		rb.AddForce(new Vector2((speed * dir), upForce));

		//--rotate to face direction of travel
		Vector2 moveDirection = rb.velocity;

     	if (moveDirection != Vector2.zero) {
        	
        	if(MovementDirection == MovementDirections.Left){
        		float angle = Mathf.Atan2(moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
    		}else {
    			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
    			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    		}
     	}

		//--move back onto screen when off the edge
		if (transform.position.x < leftConstraint - buffer) {
			transform.position = new Vector3 (rightConstraint + buffer, transform.position.y, transform.position.z);
		}

		if (transform.position.x > rightConstraint + buffer) {
			transform.position = new Vector3 (leftConstraint - buffer, transform.position.y, transform.position.z);
		}


	}

	
}

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
    private float topConstraint;
    public bool hasMoved = false;
    public GameObject Instruction;
    public PlayerResetAtEdge PlayerResetAtEdge;
	private float upForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		if(PlayerResetAtEdge){
			//--if duel mode
			topConstraint = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - 0.5f;
		} else {
			//--story mode
			topConstraint = 7f;
		}
        
        // Debug.Log("top constraint = "+topConstraint);
	}

	public void MoveToStartPos(){

		Debug.Log("Move "+gameObject.name+" to start pos");

		if(PlayerResetAtEdge){
			//--start positions
	        if(MovementDirection == MovementDirections.Left){
				startPosX = PlayerResetAtEdge.rightConstraint;
				transform.position = new Vector3(startPosX,startPosY,0);
				dir = -1;
	    	} else {
	    		startPosX = PlayerResetAtEdge.leftConstraint;
	    		transform.position = new Vector3(startPosX,startPosY,0);
	    	}
    	} else {
    		//--start wherever it is
    		Debug.Log("move to start 1");
    	}

    	//--cancel their velocity
		rb.velocity = Vector2.zero;

		gameObject.transform.rotation = Quaternion.identity;
	}
	

	void FixedUpdate () {

		upForce = defaultUpForce;
		movingUp = false;
		// Debug.Log("curent pos = "+transform.position.y);

		if(PlayerController.alive){

			if(MovementDirection == MovementDirections.Left){
				//--moving right to left

				if(TouchControls.RightPressed) {

					if(transform.position.y < topConstraint){
						movingUp = true;
						upForce = defaultUpForce + upSpeed;
					}
					
					if(!hasMoved){
						hasMoved = true;
						Instruction.GetComponent<Animator>().Play("FadeOut");
					}
				} 

			} else {
				//--moving left to right
				if(TouchControls.LeftPressed) {

					if(transform.position.y < topConstraint){
						movingUp = true;
						upForce = defaultUpForce + upSpeed;
					}
					
					if(!hasMoved){
						hasMoved = true;
						Instruction.GetComponent<Animator>().Play("FadeOut");
					}
				} 
			}
			
		}

		//--check if on autopilot - if not, fall
		if(autoPilot){
			upForce = defaultUpForce + upSpeed/2.1f;
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
	}
}

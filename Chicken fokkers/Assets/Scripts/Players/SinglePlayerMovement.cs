using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour {

    public float speed = 1f; //--force
    public float upSpeed = 1f; //--force
    public bool movingUp = false;
    public float defaultUpForce = 1;
    private Rigidbody2D rb;
    public Renderer rend;
    public TouchControls TouchControls;
    public SinglePlayerController PlayerController;
    private float startPosX; 
    private float startPosY = 3f; 
    public Camera cam;
    public bool autoPilot = true;
    private float topConstraint;
    public bool hasMoved = false;
    public GameObject Instruction;
	private float upForce;
	private int dir = 1;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
        topConstraint = -3f;
        Debug.Log("top constraint = "+topConstraint);
	}

	public void MoveToStartPos(){

		Debug.Log("Move "+gameObject.name+" to start pos");

		//--start positions
		startPosX = PlayerResetAtEdge.leftConstraint;
		transform.position = new Vector3(startPosX,startPosY,0);

    	//--cancel their velocity
		rb.velocity = Vector2.zero;
		gameObject.transform.rotation = Quaternion.identity;
	}
	

	void FixedUpdate () {

		upForce = defaultUpForce;
		movingUp = false;

		if(PlayerController.alive){

			//--moving left to right
			if(TouchControls.LeftPressed || TouchControls.RightPressed) {

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

		//--check if on autopilot - if not, fall
		if(autoPilot){
			upForce = defaultUpForce + upSpeed/1.85f;
		} 

		rb.AddForce(new Vector2((speed * -1), upForce));

		//--rotate to face direction of travel
		Vector2 moveDirection = rb.velocity;

     	if (moveDirection != Vector2.zero) {
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     	}
	}
}

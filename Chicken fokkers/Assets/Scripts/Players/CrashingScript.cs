using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingScript : MonoBehaviour {

    public float speed = 1f; //--force
    public float upSpeed = 1f; //--force
    private Rigidbody2D rb;
    public enum MovementDirections {Right = 0, Left = 1} 
    public MovementDirections MovementDirection= MovementDirections.Right & MovementDirections.Left;
    public float defaultUpForce = 1;
    public GameObject Explosion;
    public GameObject Wheel;
    private int dir = 1;
    private float upForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

        if(MovementDirection == MovementDirections.Left){
			dir = -1;
    	}
	}
	
	void FixedUpdate () {
		upForce = defaultUpForce;

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

	void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Ground"){
			// Debug.Log("crashed to ground");

			Instantiate(Explosion, transform.position, Quaternion.Euler(0, 0, gameObject.transform.eulerAngles.z));

			Destroy(gameObject);

        }
    }

    public void RemoveWheel(){
        Wheel.SetActive(false);
    }
}

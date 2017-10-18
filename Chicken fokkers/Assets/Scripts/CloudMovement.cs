using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	public float speed = 1f;
	private float buffer = 2f;
    private float leftConstraint;
    private float rightConstraint;
    public Camera cam;

	void Start(){

        leftConstraint = cam.ScreenToWorldPoint (new Vector3 (0.0f, 0.0f, 0)).x;
        rightConstraint = cam.ScreenToWorldPoint (new Vector3 (Screen.width, 0.0f, 0)).x;
	}
	
	// Update is called once per frame
	void Update () {
		// transform.position = transform.position + speed;
		// Debug.Log("speed of "+gameObject.name+" is "+speed);

		transform.Translate(Vector2.right * Time.deltaTime * speed);

		//--move back onto screen when off the edge
		if (transform.position.x > rightConstraint + buffer) {
			transform.position = new Vector3 (leftConstraint - buffer, transform.position.y, transform.position.z);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour {

	public GameObject target;
	public GameObject Rotator;
	public bool isActive = false;
	public float turnSpeed = 0.05f;
	public float minAngle;
	public float maxAngle;
	private float angle;
	private float initialAngle;

	void Start(){
		initialAngle = 210f;
	}

	void Update () {

		if(isActive){

			//--get angle towards target
			angle = Mathf.Atan2(target.transform.position.y - Rotator.transform.position.y, target.transform.position.x - Rotator.transform.position.x) * Mathf.Rad2Deg;

			// Debug.Log("head angle = "+angle);

			//--rotate towards target
			if((angle >= minAngle) && (angle <= maxAngle)){
				Rotator.transform.rotation = Quaternion.Lerp(Rotator.transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.time * turnSpeed);
			}

			if(!target.activeSelf){
				isActive = false;
				target = null;
			} 
	 	
	 	} else {
	 		target = null;
	 		//--go back to start rotation
	 		Rotator.transform.rotation = Quaternion.Lerp(Rotator.transform.rotation, Quaternion.Euler(0f, 0f, initialAngle), Time.time * turnSpeed);
	 	}

	}

	void OnTriggerEnter2D(Collider2D other) {
		// Debug.Log("head detected "+other.name);

		if(isActive == false){
			Debug.Log("turret ready to shoot");
			if (other.transform.name == "PlayerCollider"){
				isActive = true;
				target = other.transform.parent.gameObject;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {

		if(isActive == true && other.transform.parent.name == target.name){
			Debug.Log("deactivate head "+transform.name);
			isActive = false;
		}
	}
}

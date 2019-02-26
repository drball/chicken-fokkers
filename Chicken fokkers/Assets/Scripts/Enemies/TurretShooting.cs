using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {

	public GameObject target;
	private Vector3 initialScale;
	public GameObject Rotator;
	public bool isActive = false;
	public float turnSpeed = 0.05f;
	public float fireRate = 1f;
	public GameObject Bullet;
	public Transform FireFrom;
	public float minAngle;
	public float maxAngle;
	private float angle;
	public float initialAngle;
	
	// Update is called once per frame
	void Update () {

		if(isActive){

			//--get angle towards target
			angle = Mathf.Atan2(target.transform.position.y - Rotator.transform.position.y, target.transform.position.x - Rotator.transform.position.x) * Mathf.Rad2Deg;

			// Debug.Log("angle = "+angle);

			//--rotate towards target
			if((angle >= minAngle) && (angle <= maxAngle)){
				Rotator.transform.rotation = Quaternion.Lerp(Rotator.transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.time * turnSpeed);
			}


	 	} else {
	 		CancelInvoke("Shoot");
	 		target = null;
	 		//--go back to start rotation
	 		Rotator.transform.rotation = Quaternion.Lerp(Rotator.transform.rotation, Quaternion.Euler(0f, 0f, initialAngle), Time.time * turnSpeed);
	 	}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("turret "+transform.name+" detected "+other.name);

		if(isActive == false){
			Debug.Log("turret ready to shoot");
			if (other.transform.name == "PlayerCollider"){
				
				isActive = true;
				target = other.transform.parent.gameObject;
				Debug.Log("tbc turret has targetted "+target.name);
				
				InvokeRepeating("Shoot", fireRate, 1);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(isActive == true && other.transform.parent.name == target.name){
			DisableShooting();
		}
	}

	void Shoot(){

		// Debug.Log("attempt shoot");
		if(target){
			if(target.activeSelf){
				GameObject newBullet = Instantiate(Bullet, FireFrom.position, FireFrom.rotation);
				// Debug.Log("New bullet from "+transform.name+", fired at angle = "+angle);

			} else {
				DisableShooting();
			}
		}
	}

	public void DisableShooting(){
		//--also called by enemyDamageController 
		Debug.Log("deactivate turret "+transform.name);
		isActive = false;
		CancelInvoke("Shoot");
		target = null;
	}
}
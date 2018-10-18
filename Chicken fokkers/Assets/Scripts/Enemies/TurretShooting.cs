using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {

	public GameObject target;
	private Vector3 initialScale;
	private Vector3 reverseScale;
	public bool isActive = false;
	private float distance;
	public float fireRange = 5;
	private float turnSpeed = 0.01f;
	public float fireRate = 1f;
	public GameObject Bullet;
	public Transform FireFrom;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
		reverseScale = new Vector3(initialScale.x, -initialScale.y, initialScale.z);
		Debug.Log("turret");
	}
	
	// Update is called once per frame
	void Update () {

		if(isActive){

			//--get angle towards target
			var angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

			//--rotate towards target
	 		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.time * turnSpeed);

 			//--flip if on other side
	 		// if(angle > 90 || angle < -90){
				// transform.localScale = reverseScale;
	 		// } else {
	 		// 	transform.localScale = initialScale;
	 		// }

	 		// distance = Vector2.Distance(transform.position, target.transform.position);


	 	} else {
	 		CancelInvoke("Shoot");
	 		target = null;
	 		// Debug.Log("cancel shoot");
	 	}

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("turret detected "+other.name);

		if(isActive == false){
			Debug.Log("turret ready to shoot");
			if (other.transform.parent.tag == "Player"){
				
				isActive = true;
				target = other.transform.parent.gameObject;
				Debug.Log("tbc turret has targetted "+target.name);
				
				InvokeRepeating("Shoot", fireRate, 1);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		Debug.Log("trogger exit");

		if(isActive == true){
			if (other == target){
				isActive = false;
			}
		}
	}

	void Shoot(){
		Debug.Log("New bullet");
		Instantiate(Bullet, FireFrom.position, FireFrom.rotation);
	}

}
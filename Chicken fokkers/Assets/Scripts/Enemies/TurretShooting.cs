using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour {

	public GameObject target;
	private Vector3 initialScale;
	public bool isActive = false;
	private float distance;
	private float turnSpeed = 0.01f;
	public float fireRate = 1f;
	public GameObject Bullet;
	public Transform FireFrom;
	public float minAngle;
	public float maxAngle;
	private float angle;
	public int shootCount;

	// Use this for initialization
	void Start () {
		initialScale = transform.localScale;
		Debug.Log("turret");
	}
	
	// Update is called once per frame
	void Update () {

		if(isActive){

			//--get angle towards target
			angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

			// Debug.Log("angle = "+angle);

			//--rotate towards target
			if((angle >= minAngle) && (angle <= maxAngle)){
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), Time.time * turnSpeed);
			}
	 		
	 		// distance = Vector2.Distance(transform.position, target.transform.position);


	 	} else {
	 		CancelInvoke("Shoot");
	 		target = null;
	 		Debug.Log("cancel shoot");
	 	}

	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("turret detected "+other.name);

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
		Debug.Log("trogger exit");

		if(isActive == true && other == target){
			Debug.Log("deactivate turret");
			isActive = false;
		}
	}

	void Shoot(){

		Debug.Log("attempt shoot");

		if(target.activeSelf){
			shootCount++;
			GameObject newBullet = Instantiate(Bullet, FireFrom.position, FireFrom.rotation);
			newBullet.transform.GetComponent<EnemyBullet>().Owner = gameObject;
			Debug.Log("New bullet "+shootCount+", fired at angle = "+angle);

		} else {
			isActive = false;
		}
		
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public Transform shootPos; 
	public Transform ShootRayFar;
	public bool shooting = false;
	private float fireRate = 10f;
	public GameObject Bullet; 

	// Use this for initialization
	void Start () {
		
	}

	void Update (){
		RaycastHit2D shootingHit = Physics2D.Linecast(transform.position, ShootRayFar.position, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawLine(transform.position, ShootRayFar.position, Color.red);

		if(shootingHit){
			Debug.Log("hit");
			shooting = true;
			InvokeRepeating("FireBullet", 0, fireRate);
		} else {
			shooting = false;
			CancelInvoke("FireBullet");
		}
	}

	void FireBullet() {
		GameObject newBullet = Instantiate(Bullet, transform.position, transform.rotation);
		
		//--set the owner of this bullet
		newBullet.GetComponent<BulletScript>().Owner = gameObject;
	}


	
}

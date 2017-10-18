using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public Transform shootPos; 
	public Transform ShootRayFrom;
	public Transform ShootRayTo;
	public bool shooting = false;
	private float fireRate = 0.05f; //--smaller number = faster
	public GameObject Bullet; 
	public PlayerMovement PlayerMovement;
	public GameObject Player;
	private Rigidbody2D rb; //--to get player velocity
	public PlayerController PlayerController;

	// Use this for initialization
	void Start () {
		// Debug.Log(gameObject.name+" dir="+PlayerMovement.MovementDirection);
		rb = GetComponent<Rigidbody2D>();
	}

	void Update (){

		if(PlayerController.alive == true){
			RaycastHit2D shootingHit = Physics2D.Linecast(ShootRayFrom.position, ShootRayTo.position, 1 << LayerMask.NameToLayer("Player"));
			// Debug.DrawLine(ShootRayFrom.position, ShootRayTo.position, Color.red);

			if(shootingHit){
				if(shootingHit.collider.name != gameObject.name){
								
					if(!shooting){
						shooting = true;
						InvokeRepeating("FireBullet", 0, fireRate);
						Debug.Log("start shooting");
					}
				}
				
			} else {
				if(shooting){
					shooting = false;
					CancelInvoke("FireBullet");
					Debug.Log("cancel shooting");
				}
			}
		}
		
	}

	// void FixedUpdate() {
 //        RaycastHit2D shootingHit = Physics2D.Raycast(ShootRayFrom.position, rb.velocity);

 //        if ((shootingHit.collider != null) && (shootingHit.collider.tag == "Player") && (shootingHit.collider.name != gameObject.name)) {
 //        	Debug.Log(gameObject.name+" hit "+shootingHit.collider.name);
 //            if(!shooting){
	// 			shooting = true;
	// 			InvokeRepeating("FireBullet", 0, fireRate);
	// 			// Debug.Log("start shooting");
	// 		}
 //        } else {
 //        	if(shooting){
	// 			shooting = false;
	// 			CancelInvoke("FireBullet");
	// 			// Debug.Log("cancel shooting");
	// 		}
 //        }
 //    }



	void FireBullet() {

		// Debug.Log("fire bullet from "+Player.name+" at rotation "+Player.transform.rotation.z);
		
		if(PlayerMovement.MovementDirection == PlayerMovement.MovementDirections.Left){
			GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, Player.transform.eulerAngles.z+90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = gameObject;
		} else {
			GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, Player.transform.eulerAngles.z-90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = gameObject;
		}

	}


	
}

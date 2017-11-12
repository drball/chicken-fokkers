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
	public PlayerController PlayerController;
	public bool shootingHit = false;

	// Use this for initialization
	void Start () {
		// Debug.Log(gameObject.name+" dir="+PlayerMovement.MovementDirection);
	}

	void Update (){

		if(PlayerController.alive == true && PlayerMovement.autoPilot == false){

			if(shootingHit){
			
				if(!shooting){
					shooting = true;
					InvokeRepeating("FireBullet", 0, fireRate);
					Debug.Log("start shooting");
				}

			} else {
				if(shooting){
					shooting = false;
					CancelShooting();
					Debug.Log("cancel shooting");
				}
			}

			shootingHit = false;
		} 
	}

	void OnTriggerStay2D(Collider2D other) {

		// Debug.Log(gameObject.name+" touching!!!!"+other.name);
		// Debug.Log(transform.parent.name+" touching "+other.transform.parent.name+" "+other.name);

        if (other.tag == "Player" && (other.transform.parent.name != transform.parent.name)){
        	// Debug.Log("detector hit "+other.name);
    		shootingHit = true;
        }

    }

	public void CancelShooting(){
		Debug.Log("cencel shooting tho");
		CancelInvoke("FireBullet");
	}	

	void FireBullet() {

		// Debug.Log("fire bullet from "+Player.name+" at rotation "+Player.transform.rotation.z);
		
		if(PlayerMovement.MovementDirection == PlayerMovement.MovementDirections.Left){
			GameObject newBullet = Instantiate(Bullet, shootPos.transform.position, Quaternion.Euler(0, 0, Player.transform.eulerAngles.z+90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = Player;
		} else {
			GameObject newBullet = Instantiate(Bullet, shootPos.transform.position, Quaternion.Euler(0, 0, Player.transform.eulerAngles.z-90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = Player;
		}

	}


	
}

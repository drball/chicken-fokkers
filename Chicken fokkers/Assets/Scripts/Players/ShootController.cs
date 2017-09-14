using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public Transform shootPos; 
	public Transform ShootRayFrom;
	public Transform ShootRayTo;
	public bool shooting = false;
	private float fireRate = 10f;
	public GameObject Bullet; 
	public PlayerMovement PlayerMovement;

	// Use this for initialization
	void Start () {
		Debug.Log(gameObject.name+" dir="+PlayerMovement.MovementDirection);
	}

	void Update (){
		RaycastHit2D shootingHit = Physics2D.Linecast(ShootRayFrom.position, ShootRayTo.position, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawLine(ShootRayFrom.position, ShootRayTo.position, Color.red);

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
		
		if(PlayerMovement.MovementDirection == PlayerMovement.MovementDirections.Left){
			GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, 90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = gameObject;
		} else {
			GameObject newBullet = Instantiate(Bullet, transform.position, Quaternion.Euler(0, 0, -90));
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = gameObject;
		}

	}


	
}

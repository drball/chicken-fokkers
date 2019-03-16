using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour {

	public Transform shootPos; 
	public bool shooting = false;
	public GameObject Bullet; 
	public GameObject BulletLarge; 
	public GameObject DefaultBullet; 
	public PlayerMovement PlayerMovement;
	public GameObject Player;
	public PlayerController PlayerController;
	public bool shootingHit = false;
	private float defaultFireRate = 0.15f;
	public float fireRate; //--smaller number = faster
	private float fireRateIncrement = 0.015f;
	public float angularDeviation = 0f; //--0 is most precise 
	public List<float> shootingAngles; //--a list for our pregenerated random angles
	private int shootingAngleNum = 0;
	private Quaternion bulletAngle;

	// Use this for initialization
	void Awake () {
		ResetFireRate();
	}

	void Start () {

		for(int i = 0; i < 10; i++){
			shootingAngles.Add(Random.Range(-angularDeviation, angularDeviation));
		}
	}

	void Update (){

		if(PlayerController.alive == true && PlayerMovement.autoPilot == false){

			if(shootingHit){
			
				if(!shooting){
					shooting = true;
					InvokeRepeating("FireBullet", 0, fireRate);
					// Debug.Log("start shooting");
				}

			} else {
				if(shooting){
					shooting = false;
					CancelShooting();
					// Debug.Log("cancel shooting");
				}
			}

			shootingHit = false;
		} 
	}

	void OnTriggerStay2D(Collider2D other) {

		// Debug.Log(gameObject.name+" touching!!!!"+other.name);
		// Debug.Log(transform.parent.name+" touching "+other.transform.parent.name+" "+other.name);

        if (other.tag == "Enemy" || (other.tag == "Player" && (other.transform.parent.name != transform.parent.name))){
        	// Debug.Log("detector hit "+other.name);
    		shootingHit = true;
        }

    }

	public void CancelShooting(){
		// Debug.Log("cencel shooting tho");
		CancelInvoke("FireBullet");
	}	

	public void ResetFireRate(){
		fireRate = defaultFireRate;

		Bullet = DefaultBullet;
	}

	public void IncreaseFireRate(){
		fireRate = fireRate - fireRateIncrement;

		//--if we're currently shooting, cancel the interval and start it again with new firerate
		CancelShooting();

		if(shootingHit){
			Debug.Log("start shooting again");
			
			InvokeRepeating("FireBullet", 0, fireRate);
		
			if(!shooting){
				shooting = true;
			}
		} 
	}

	public void ChangeBulletToLarge(){
		Debug.Log("change bullet to large");
		Bullet = BulletLarge;
	}

	void FireBullet() {

		//--not sure why we're checking if there's a playermovement script? 

		
		if(PlayerMovement){
			if(PlayerMovement.MovementDirection == PlayerMovement.MovementDirections.Left){
				bulletAngle = Quaternion.Euler(0, 0, Player.transform.eulerAngles.z + shootingAngles[shootingAngleNum] - shootPos.transform.localEulerAngles.z);
				GameObject newBullet = Instantiate(Bullet, shootPos.transform.position, bulletAngle);
			
				//--set the owner of this bullet
				newBullet.GetComponent<BulletScript>().Owner = Player;
			} else {
				bulletAngle = Quaternion.Euler(0, 0, Player.transform.eulerAngles.z + shootingAngles[shootingAngleNum] + shootPos.transform.localEulerAngles.z);
				GameObject newBullet = Instantiate(Bullet, shootPos.transform.position, bulletAngle);
				
				//--set the owner of this bullet
				newBullet.GetComponent<BulletScript>().Owner = Player;
			}
		} else {
			bulletAngle = Quaternion.Euler(0, 0, Player.transform.eulerAngles.z + shootingAngles[shootingAngleNum] - 90);
			GameObject newBullet = Instantiate(Bullet, shootPos.transform.position, bulletAngle);	
			
			//--set the owner of this bullet
			newBullet.GetComponent<BulletScript>().Owner = Player;
		}	

		shootingAngleNum++;

		if(shootingAngleNum >= 10){
			shootingAngleNum = 0;
		}
	}
}

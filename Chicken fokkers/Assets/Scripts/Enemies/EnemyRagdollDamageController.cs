using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdollDamageController : MonoBehaviour {

	public SpriteRenderer[] Rends; //--anything that changes colour when hit
	public int health;
	private int initialHealth;
	public GameObject Explode;
	public SwitchToRigidbody SwitchToRigidbodyScript;
	public TurretShooting ShootingScript; //--for disabling shooting
	public CapsuleCollider2D Collider; //--for disabling when enemy is dead
	public GameObject Bounds; //--to remove these when dead

	// Use this for initialization
	void Start () {
		initialHealth = health;
		ResetColour();
		Explode.SetActive(false);
	}
	
	public void HitByBullet(){
		Debug.Log("chicken hit by bullet. health = "+health);

		// Debug.Log("hot by bullet called");
		if(health > 0) {
			// Debug.Log(gameObject.name+"hit by bullet");
			health--;
			
			Invoke("ResetColour", 0.06f);
			// UpdateHealthBar();

			foreach(SpriteRenderer Rend in Rends){
				Rend.color = new Color(255, 0, 0, 0.5f); //--make it red
			}

			if(health <= 0 ){
				Die();
			} 
		}
	}

	void ResetColour(){
		foreach(SpriteRenderer Rend in Rends){
			Rend.color = new Color(255f, 255f, 255f, 1f);
		}
	}

	public void Die(){
		Debug.Log("chicken die!");
		Explode.SetActive(true);
		Explode.transform.parent = null;
		health = 0;
		Collider.enabled = false;
		ShootingScript.DisableShooting();
		Debug.Log("shootingscript = "+ShootingScript.isActive);
		Bounds.SetActive(false);

		if(health == 0){
			//--check if this isn't being killed by ramming
			SwitchToRigidbodyScript.SwitchAndPush(new Vector2(1,0.2f));
		}

		if(ShootingScript){
			ShootingScript.DisableShooting();
		}
	}


}


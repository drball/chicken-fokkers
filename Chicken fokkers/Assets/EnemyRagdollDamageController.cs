using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdollDamageController : MonoBehaviour {

	public SpriteRenderer[] Rends; //--anything that changes colour when hit
	public int health;
	private int initialHealth;
	public GameObject Explode;
	public SwitchToRigidbody SwitchToRigidbodyScript;
	

	// Use this for initialization
	void Start () {
		initialHealth = health;
		ResetColour();
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

	void Die(){
		Debug.Log("chicken die!");
		Explode.SetActive(true);
		Explode.transform.parent = null;
		SwitchToRigidbodyScript.SwitchAndPush(new Vector2(0,0));
	}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

	public GameObject Player;
	public int health = 100;
	public SpriteRenderer Rend;
	public PlayerController PlayerController;

	// Use this for initialization
	void Start () {
		ResetColour();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HitByBullet(){
		Debug.Log(gameObject.name+"hit by bullet");
		health--;
		Rend.color = new Color(255f, 0, 0, 1f); //--make it red
		Invoke("ResetColour", 0.06f);

		if(health < 0){
			PlayerController.Die();
		}
	}

	void ResetColour(){
		Rend.color = new Color(255f, 255f, 255f, 1f);
	}


}

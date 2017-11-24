using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

	public int abilityNum = 0;
	private int abilityNumMax = 5;
	public ShootController ShootController;

	// Use this for initialization
	void Start () {

		// Invoke("Test", 1f);
	}
	
	public void CollectedPickup () {

		//--instrease player's ability
		IncreasePlayerAbility();
		
	}

	void IncreasePlayerAbility(){

		if(abilityNum < abilityNumMax){
			abilityNum++;

			//--ability list
			if(abilityNum < 5){
				ShootController.IncreaseFireRate();
			} else if (abilityNum == 5){
				ShootController.ChangeBulletToLarge();
			}
		}

	}

	public void ResetAbility(){
		abilityNum = 0;
	}

	// void Test(){
	// 	IncreasePlayerAbility();
	// 	IncreasePlayerAbility();
	// 	IncreasePlayerAbility();
	// 	IncreasePlayerAbility();
	// 	IncreasePlayerAbility();
	// }
}

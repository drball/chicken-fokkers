using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; //--enables us to access <Text>
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

	public int abilityNum = 0;
	private int abilityNumMax = 5;
	public ShootController ShootController;
	public PlayerController PlayerController;
	private Text AbilityText;
	private int playerNum = 1;
	public Animator AbilityAnimator;

	void Start(){
		playerNum = PlayerController.playerNum;
		// Debug.Log(transform.name + " playernum### = "+playerNum);

		if(playerNum == 1){
			AbilityText = GameObject.Find("Ability1Text").GetComponent<Text>();
			AbilityAnimator = GameObject.Find("AbilityCounter1").GetComponent<Animator>();
			// AbilityText.text = "7";
		} else {
			AbilityText = GameObject.Find("Ability2Text").GetComponent<Text>();
			AbilityAnimator = GameObject.Find("AbilityCounter2").GetComponent<Animator>();
		}


	}
	
	public void CollectedPickup () {

		//--called from pickup script
		IncreasePlayerAbility();
	}

	void IncreasePlayerAbility(){

		if(abilityNum < abilityNumMax){
			abilityNum++;
			AbilityText.text = abilityNum.ToString();
			AbilityAnimator.SetTrigger("Flash");

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
}

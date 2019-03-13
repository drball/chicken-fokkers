using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionController : MonoBehaviour {

	public bool paidVersion = false;
	// public Purchaser PurchaserScript;

	void Awake () {

		//--because this is a singleton, we want only one
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			//--destroy others like this
			Debug.Log("destroying this duplicate of LevelsController");
			Destroy(gameObject);
		}

		//--check if we have bought the no-ads version
		if(PlayerPrefs.GetInt("hasPaid") == 1){
			paidVersion = true;
		}
	}

	public void PurchaseNoAds(){
		//--IAP for no ads 
		// PurchaserScript.BuyNonConsumable();

	}

	public void SwitchToPaid(){
		//--button has been pressed and the payment has gone through
		//--called from the purchaser script
		paidVersion = true;
		//--save this 
		PlayerPrefs.SetInt("hasPaid",1);
		Debug.Log("set paid");
		Application.LoadLevel("menu");
	}
}
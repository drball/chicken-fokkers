using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour {

	public int abilityNum = 0;
	private int abilityNumMax = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	public void CollectedPickup () {
		if(abilityNum < abilityNumMax){
			abilityNum++;
		}
	}
}

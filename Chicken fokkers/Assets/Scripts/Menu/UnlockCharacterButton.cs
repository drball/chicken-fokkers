using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--this stores the current selected string for this character - used by playerSelectScript when pressed

public class UnlockCharacterButton : MonoBehaviour {

	public string selectedCharacter;
	public int playerNum;
	public PlayerSelectScript PlayerSelectScript;

	// Use this for initialization
	void Start () {
		selectedCharacter = "Rocket";
		playerNum = 1;
	}
	
	public void PressedUnlockButton() {
		Debug.Log("p"+playerNum+"pressed unlock button for "+selectedCharacter);
		PlayerSelectScript.showUnlockModal(selectedCharacter); 
	}
}
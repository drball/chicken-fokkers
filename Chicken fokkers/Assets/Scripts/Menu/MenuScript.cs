using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public GameObject LoadingPanel;

	// Use this for initialization
	void Start () {
		LoadingPanel.SetActive(false);
	}
	
	void StartGame(){
		//--show loading panel because there's a delay
		LoadingPanel.SetActive(true);
		
		Application.LoadLevel("main");
	}

	void RateBtnPressed(){

	}

	void TwitterBtnPressed(){
		Application.OpenURL("https://www.twitter.com/davidonionball");
	}

	void LikeBtnPressed(){
		Application.OpenURL("https://www.facebook.com/BotSumoGame/");
	}

	void FacebookBtnPressed(){

	}
}

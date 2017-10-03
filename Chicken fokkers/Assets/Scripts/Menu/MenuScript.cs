using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public GameObject LoadingPanel;
	public GameObject CreditsPanel;
	public GameObject MoreGamesPanel;

	// Use this for initialization
	void Start () {
		LoadingPanel.SetActive(false);
	}
	
	void StartGame(){
		//--show loading panel because there's a delay
		LoadingPanel.SetActive(true);
		Debug.Log("hello");
		Application.LoadLevel("main");
	}

	public void RateBtnPressed(){

	}

	public void TwitterBtnPressed(){
		Application.OpenURL("https://www.twitter.com/davidonionball");
	}

	public void LikeBtnPressed(){
		Application.OpenURL("https://www.facebook.com/BotSumoGame/");
	}

	public void FacebookBtnPressed(){

	}

	public void PlayBtnPressed(){
		StartGame();
	}
}

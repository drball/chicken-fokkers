using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	public LevelsController LevelsController;
	public GameObject CreditsPanel;
	public GameObject MoreGamesPanel;

	// Use this for initialization
	void Start () {
		LevelsController = GameObject.Find("LevelsController").GetComponent<LevelsController>();
		LevelsController.HideLoadingDialog();
		CreditsPanel.SetActive(false);
		MoreGamesPanel.SetActive(false);
	}
	
	void StartDuelGame(){
		//--show loading panel because there's a delay
		LevelsController.ShowLoadingDialog();
		// Debug.Log("hello");
		Application.LoadLevel("playerSelect");
	}

	void StartStoryGame(){
		//--show loading panel because there's a delay
		LevelsController.ShowLoadingDialog();
		Debug.Log("starting story game");
		Application.LoadLevel("levelSelect");
	}

	public void RateBtnPressed(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DavidDickBall.ChickenFokkers&referrer=utm_source%3Dingame%26utm_medium%3Dingamelink%26utm_campaign%3Dingamelink");
	}

	public void TwitterBtnPressed(){
		Application.OpenURL("https://www.twitter.com/davidonionball");
	}

	public void LikeBtnPressed(){
		// Application.OpenURL("https://www.facebook.com/BotSumoGame/");
	}

	public void FacebookBtnPressed(){
		Application.OpenURL("https://www.facebook.com/davidonionball");
	}

	public void MusicCreditBtnPressed(){
		Application.OpenURL("https://www.newgrounds.com/audio/listen/729086");
	}

	public void WebsiteBtnPressed(){
		Application.OpenURL("http://daviddickball.uk");
	}

	public void BotsumoBtnPressed(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DavidDickBall.RoboSumo&referrer=utm_source%3Dinapp%26utm_medium%3Dlink%26utm_campaign%3Dfokker");
	}

	public void BattleAreanBtnPressed(){
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DavidDickBall.BotSumoBattleArena&referrer=utm_source%3Dinapp%26utm_medium%3Dlink%26utm_campaign%3Dfokker");
	}

	public void ETSBtnPressed() {
		Application.OpenURL("https://play.google.com/store/apps/details?id=com.DavidDickBall.EscapeTheSector&referrer=utm_source%3Dinapp%26utm_medium%3Dlink%26utm_campaign%3Dfokker");
	}

	public void PlayDuelBtnPressed(){
		StartDuelGame();
	}

	public void PlayStoryBtnPressed(){
		StartStoryGame();
	}

}

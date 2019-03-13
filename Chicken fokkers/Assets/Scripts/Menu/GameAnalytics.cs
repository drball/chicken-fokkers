using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameAnalytics : MonoBehaviour {

    public int timesPlayed;

    void Awake(){
        timesPlayed = PlayerPrefs.GetInt("timesPlayed");
    }
	
	void StartLevel() {
	    //--called by game controller at end of game when the level is reset

        timesPlayed = PlayerPrefs.GetInt("timesPlayed");

	    PlayerPrefs.SetInt("timesPlayed", timesPlayed+=1);

        //--send analytics event
        Analytics.CustomEvent("played", new Dictionary<string, object>
        {
            { "timesPlayed", timesPlayed }
        });

        Debug.Log("times played = "+timesPlayed);
	}

    void ChoseCharacter(string botName){
        //--called from sendmessage from the character select screen

        //--send analytics event
        Analytics.CustomEvent("characterSelection", new Dictionary<string, object>
        {
            { "characterSelected", botName }
        });
    }
}

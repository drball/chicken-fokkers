using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public void LoadMainMenu(){
		//--for pause modal
		Time.timeScale = 1; //--unpause
		Application.LoadLevel("menu");
	}

	public void LoadLevelSelect(){
		//--for back button
		Application.LoadLevel("levelSelect");
	}
}

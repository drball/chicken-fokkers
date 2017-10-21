using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--a singleton for remembering stuff about levels

public class LevelsController : MonoBehaviour {

	public string currentLevel = "main";
	public GameObject LoadingDialog; 

	void Awake () {

		//--because this is a singleton, we want only onee
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			//--destroy others like this
			Debug.Log("destroying this duplicate of LevelsController");
			Destroy(gameObject);
		}
	}

	void Start() {
		Debug.Log("LevelsController has started");
		
		HideLoadingDialog();
	}

	// void SelectLevel(destinationTitle : String){
	// 	//--select a level - then load the playerSelect screen
	// 	LoadingDialog.SetActive(true);
	// 	yield WaitForSeconds(0.25);

	// 	currentLevel = destinationTitle;
	// 	Debug.Log("levelscontroller is remembering level "+destinationTitle);
	// 	Application.LoadLevel("playerSelect");
	// }

	public IEnumerator LoadSelectedLevel(){
		//--load the level we selected earlier
		//--called from the playerSelect screen
		ShowLoadingDialog();

		yield return new WaitForSeconds(0.25f);

		Debug.Log("levelscontroller is loading level "+currentLevel);
		Application.LoadLevel(currentLevel);
	}


	void ShowLoadingDialog(){
		Debug.Log("show loading");
		LoadingDialog.SetActive(true);
	}

	void HideLoadingDialog(){
		Debug.Log("hide loading");
		LoadingDialog.SetActive(false);
	}

	void Update () {

		if(Input.GetKeyDown(KeyCode.Escape) == true) {
			Application.LoadLevel("menu");
		}
	}
}

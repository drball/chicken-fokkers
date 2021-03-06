﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObstacleCountdown : MonoBehaviour
{
	[HideInInspector] public GameController GameController;
    public bool isShowingObstacle;
	public bool canShowObstacle;
	public int countdown;
	private int countdownInitial;
	public GameObject point;
	public GameObject[] Players;
	public float Player1Distance;
	public float Player2Distance;
	private float maxDistance;
	public GameObject obstacleObj;
	private GameObject obstacleInstance;

    void Start()
    {
        Players[0] = GameController.Player1Obj;
        Players[1] = GameController.Player2Obj;

        countdownInitial = countdown;
        maxDistance = 5.5f;
        obstacleObj.SetActive(false);
        StartCountdown();
        
    }

    void StartCountdown(){
    	countdown = countdownInitial;
    	InvokeRepeating("DecrementCountdown",1,1);
    }

    void StopCountdown(){
    	CancelInvoke("DecrementCountdown");
    }

    void DecrementCountdown(){

    	if (countdown > 0) {
    		countdown--;
    	} else {

    		canShowObstacle = true;
    		
    	}
    }

    void AddObstacle(){
		obstacleInstance = Instantiate(obstacleObj, obstacleObj.transform.position, obstacleObj.transform.rotation);
		obstacleInstance.SetActive(true);
		canShowObstacle = false;
		isShowingObstacle = true;
    }

    public void RemoveObstacle(){
    	//--flash the obstacle, then remove the instance
		obstacleInstance.GetComponent<Animator>().SetTrigger("FadeOut");
    	Destroy(obstacleInstance, 3f);
        Debug.Log("Remove the obstacle");

    	//--restart the countdown
    	StartCountdown();
    }

    void Update(){

    	Player1Distance = Vector2.Distance(point.transform.position,Players[0].transform.position);
		Player2Distance = Vector2.Distance(point.transform.position,Players[1].transform.position);

		if(canShowObstacle){
			

			if (Player1Distance > maxDistance && Player2Distance > maxDistance){
				Debug.Log("players are far enough to show obstacle");
				StopCountdown();
				AddObstacle();
			} 
		}
    }


    
}

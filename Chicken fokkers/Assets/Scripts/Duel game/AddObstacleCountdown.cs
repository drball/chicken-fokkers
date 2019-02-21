using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObstacleCountdown : MonoBehaviour
{
	public bool isShowingObstacle;
	public int countdown;
	private int countdownInitial;
	public GameObject point;
	public GameObject[] Players;
	public float Player1Distance;
	public float Player2Distance;
	private float maxDistance;
	public GameObject obstacleObj;

    void Start()
    {
        countdownInitial = countdown;
        maxDistance = 5.5f;
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
    		if(isShowingObstacle == false){
				//--check distance of both players 

				Player1Distance = Vector2.Distance(point.transform.position,Players[0].transform.position);
				Player2Distance = Vector2.Distance(point.transform.position,Players[1].transform.position);

				// foreach(GameObject Player in Players){
				// 	Debug.Log("dist of "+Player.name+" = "+Vector2.Distance(point.transform.position,Player.transform.position));
				// }

				if (Player1Distance > maxDistance && Player2Distance > maxDistance){
					Debug.Log("players are far");
					isShowingObstacle = true;
					StopCountdown();
					AddObstacle();
				} else {
					Debug.Log("players are too close");
				}
				
			}
    	}
		
    }

    void AddObstacle(){

    }

    void Update(){
		
    }
}

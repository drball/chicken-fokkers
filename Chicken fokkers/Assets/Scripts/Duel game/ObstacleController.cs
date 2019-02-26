using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--check if the enemies are still alive, if not, hide this and start the countdown again

public class ObstacleController : MonoBehaviour
{
	public AddObstacleCountdown AddObstacleCountdown;
	public SwitchToRigidbody[] Enemies;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("CheckEnemies",2,2);
    }

    void CheckEnemies(){
		//--check if the enemies still alive 
		foreach (SwitchToRigidbody enemy in Enemies){
			Debug.Log("enemy "+enemy.alive);
		}

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--check if the enemies are still alive, if not, hide this and start the countdown again

public class ObstacleController : MonoBehaviour
{
	public AddObstacleCountdown AddObstacleCountdown;
	public SwitchToRigidbody[] Enemies;
	public int enemiesAlive;

    // Start is called before the first frame update
    void Start()
    {
		InvokeRepeating("CheckEnemies",5,5);
		enemiesAlive = Enemies.Length;
    }

    void CheckEnemies(){
		//--check if the enemies still alive 
		Debug.Log("check enemies");
		enemiesAlive = 0;

		foreach (SwitchToRigidbody enemy in Enemies){
			if(enemy.alive == true){
				enemiesAlive++;
			}
		}

		if (enemiesAlive <= 0){
			CancelInvoke("CheckEnemies");
			AddObstacleCountdown.RemoveObstacle();
		}
    }
}

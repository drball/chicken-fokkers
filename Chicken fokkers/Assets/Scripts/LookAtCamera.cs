using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--keeps the healthbar always level, even if parent rotates

public class LookAtCamera : MonoBehaviour {

	public GameObject targetPos;

	// Use this for initialization
	void Start () {
		
	}
	
	void LateUpdate () {
         // transform.LookAt(targetPos.transform.position); 
         transform.LookAt(Camera.main.transform.position);
     }
}

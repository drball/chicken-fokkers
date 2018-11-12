using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--keeps the healthbar always level, even if parent rotates

public class LookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void LateUpdate () {
         // transform.position = targetPos.position + offset; 
         transform.LookAt(-Camera.main.transform.position);
     }
}

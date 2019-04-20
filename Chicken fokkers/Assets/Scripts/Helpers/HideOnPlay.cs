// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class HideOnPlay : MonoBehaviour {

	void Start () {
		
		if(Time.deltaTime < 0.1){
			Debug.Log(transform.name+" has been hidden at time:"+Time.deltaTime);
			gameObject.SetActive(false);
		}
	}
	
}

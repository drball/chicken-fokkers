using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertsController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey("space") ) {
			ShowAdvert();
		}
	}

	public void ShowAdvert(){
		Advertisement.Show();
	}
}

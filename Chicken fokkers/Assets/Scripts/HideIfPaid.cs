using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideIfPaid : MonoBehaviour {

	VersionController VersionController;

	// Use this for initialization
	void Start () {
		VersionController = GameObject.Find("VersionController").GetComponent<VersionController>();

		if(VersionController.paidVersion == true){
			gameObject.SetActive(false);
		} else {
			gameObject.SetActive(true);
		}
	}
	
}

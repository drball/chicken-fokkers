using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOnIOS : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		#if UNITY_IOS
			gameObject.SetActive(false);
		#endif
	}
	
}

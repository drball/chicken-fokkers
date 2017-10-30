using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour {

	public AudioSource EngineSfx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("dir = "+gameObject.transform.rotation);
	}
}

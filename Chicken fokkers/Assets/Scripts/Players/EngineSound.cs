using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour {

	public AudioSource EngineSfx;
	
	// Update is called once per frame
	void Update () {
		
		// Debug.Log("rotation = "+gameObject.transform.rotation.z);
		float pitch = 1;

		pitch -= gameObject.transform.rotation.z * 0.65f;

		EngineSfx.pitch = pitch;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		// Destroy(gameObject, time);
	}

	void OnEnable()
    {
        Debug.Log("destory after time enabled on "+transform.name);
        Destroy(gameObject, time);
    }
	
}
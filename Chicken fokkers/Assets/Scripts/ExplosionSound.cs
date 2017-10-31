using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--plays a sound of a random pitch

public class ExplosionSound : MonoBehaviour {

	public AudioSource Sfx;

	// Use this for initialization
	void Start () {
		Sfx.pitch = Random.Range(0.5f, 1.5f);
		Sfx.Play();
	}
}

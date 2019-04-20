using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--instantly plays a sound of a random pitch - ideal for explosion or bullet

public class ExplosionSound : MonoBehaviour {

	public AudioSource Sfx;

	// Use this for initialization
	void Start () {
		Sfx.pitch = Random.Range(0.5f, 1.5f);
		Sfx.Play();
	}
}

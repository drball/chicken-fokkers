using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour {

	public AudioSource Sfx;

	// Use this for initialization
	void Start () {
		Sfx.pitch = Random.Range(0.6f, 1.5f);
		Sfx.Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour {

	public AudioSource Sfx;

	void Play(float pitch){
		Sfx.pitch = pitch;
		Sfx.Play();
	}
}

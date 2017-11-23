using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour {

	private float appearAfter = 0.22f;
	private float edgeBuffer = 2f;
	public Camera cam;
	public GameObject Pickup;
	public Vector2 location;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CreatePickup",0, appearAfter);
	}
	
	void CreatePickup(){

		location = new Vector2(
			Random.Range(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + edgeBuffer, cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - edgeBuffer),
			Random.Range(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + (edgeBuffer/2), cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - (edgeBuffer/2))
		);

		Instantiate(Pickup, location, Quaternion.identity);

		
	}

	void FixedUpdate () {

		//--debug
		if(Input.GetKey("s") ) {
			CreatePickup();
		}
	}
}

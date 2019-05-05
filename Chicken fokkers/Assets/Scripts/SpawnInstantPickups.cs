using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--spawn a blue type of pickup that works instantly - like the missiles

public class SpawnInstantPickups : MonoBehaviour {

	private float appearAfter;
	private float edgeBuffer = 2f;
	public Camera cam;
	public GameObject Pickup;
	private Vector2 location;
	private int pickupMaxAmt = 2;
	private int pickupAmt;

	// Use this for initialization
	void Start () {
		appearAfter = Random.Range(5f,10f);
		InvokeRepeating("CreatePickupIntent",appearAfter, appearAfter);
		Debug.Log("pickup appearafter = "+appearAfter);
	}

	void CreatePickupIntent(){
		//--check we can make a new pickup
		Debug.Log("createpickup intent");

		pickupAmt = GameObject.FindGameObjectsWithTag("InstantPickup").Length;
		Debug.Log("pickup amt = "+pickupAmt+" / "+pickupMaxAmt);

		if(pickupAmt < pickupMaxAmt)
		{
			CreatePickup();
		}

	}
	
	void CreatePickup(){
		Debug.Log("createpickup");

		location = new Vector2(
			Random.Range(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + edgeBuffer, cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - edgeBuffer),
			Random.Range(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + (edgeBuffer/2), cam.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - (edgeBuffer/2))
		);

		Instantiate(Pickup, location, Quaternion.identity);
	}

	void FixedUpdate () {

		//--debug
		if(Input.GetKey("i") ) {
			CreatePickupIntent();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToRigidbody : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to
    public Rigidbody2D SwitchToRb;
	private Vector2 forceAmt;

	// Use this for initialization
	void Start () {
		InitialObj.SetActive(true);
        SwitchTo.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		// Debug.Log(other.name+" hit"+gameObject.name);

        if(alive == true){

            if (other.gameObject.tag == "PlayerCollider" || other.gameObject.tag == "PlayerWheel"){

                Vector2 otherVelocity = other.transform.parent.GetComponent<Rigidbody2D>().velocity;
                Debug.Log("collided with "+other.name+" mag = "+otherVelocity.magnitude);
                SwitchAndPush(otherVelocity);
            }
        }
    }

    public void SwitchAndPush(Vector2 velocity){
        InitialObj.SetActive(false);
        SwitchTo.SetActive(true);
        alive = false;

        if(velocity.magnitude > 1){
            forceAmt = velocity * 17;
            SwitchToRb.AddForce(forceAmt, ForceMode2D.Impulse);
        }
    }
}

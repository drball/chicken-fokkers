using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--put this on a container of the objects which will be hidden and replaced with an RB

public class SwitchToRigidbody : MonoBehaviour {

	public bool alive = true;
	public GameObject InitialObj; //-- the initial object
	public GameObject SwitchTo; //--the object we'll switch to
    private Rigidbody2D SwitchToRb;
	private Vector2 forceAmt;
    public EnemyRagdollDamageController DamageController;

	// Use this for initialization
	void Start () {
		InitialObj.SetActive(true);
        SwitchTo.SetActive(false);
	}
	
	void OnTriggerEnter2D(Collider2D other) {

		Debug.Log(other.name+" hit"+gameObject.name);

        if(alive == true){

            //--if killed by ramming with a plane or something
            if (other.gameObject.tag == "PlayerCollider" || other.gameObject.tag == "PlayerWheel" || other.gameObject.tag == "DynamicLand"){

                Vector2 otherVelocity = other.transform.parent.GetComponent<Rigidbody2D>().velocity;
                Debug.Log("collided with "+other.name+" mag = "+otherVelocity.magnitude);
                
                if(DamageController){
                    //--telegraphpoles don't have a damage controller
                    DamageController.Die();
                }

                SwitchAndPush(otherVelocity);
            }
        }
    }

    public void SwitchAndPush(Vector2 velocity){

        if(alive == true){
            Debug.Log("chicken switchandpush");
            alive = false;
            InitialObj.SetActive(false);
            SwitchTo.SetActive(true);
            
            if(velocity.magnitude > 1 && SwitchToRb){
                forceAmt = velocity * 15;
                SwitchToRb.AddForce(forceAmt, ForceMode2D.Impulse);
            }
        }
    }
}

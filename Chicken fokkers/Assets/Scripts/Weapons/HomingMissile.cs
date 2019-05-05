using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    public GameObject[] possibleTargets;
	public Transform target;
	private float speed = 3f;
    private float rotateSpeed = 300f;
	private Rigidbody2D rb; 
    private BoxCollider2D collider;


    // Start is called before the first frame update
    void Start()
    {
        
        //--check possible targets & choose the furthest
        possibleTargets = GameObject.FindGameObjectsWithTag("Player");
        possibleTargets.OrderBy(possibleTarget => possibleTarget.transform.position.y).ToArray();
        
        Invoke("SetTarget",0.75f);

        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;

        rb = GetComponent<Rigidbody2D>();
    }

    void SetTarget(){
        //--do this after after a while
        target = possibleTargets[possibleTargets.Length - 1].transform;
        collider.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;

        //--turn toward target - if we have one 
        if(target){
            Vector2 direction = (Vector2)target.position - rb.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed;
            
        } 

        
    }

    void OnTriggerEnter2D(){
    	// Destroy(gameObject);
    }
}

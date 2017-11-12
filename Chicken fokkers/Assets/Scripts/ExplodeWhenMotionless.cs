using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeWhenMotionless : MonoBehaviour {

	public Rigidbody2D rb;
	public GameObject Explosion;
	
	// Update is called once per frame
	void Update () {
		Debug.Log("rb = "+rb.velocity);
		Debug.Log("rb m = "+rb.velocity.magnitude);

		if(rb.velocity.magnitude < 0.4){
			Debug.Log("explode detached wheel");
			Destroy(gameObject);
			GameObject detechedWheelExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);

		}
	}
}

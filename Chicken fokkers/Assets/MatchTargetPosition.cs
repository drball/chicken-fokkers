using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTargetPosition : MonoBehaviour
{

	public GameObject TargetObj;
	// private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = TargetObj.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayUpright : MonoBehaviour
{
	Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = initialRotation;
    }
}

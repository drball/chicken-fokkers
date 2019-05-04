using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 500f;
    private Rigidbody2D rb;

    void Start () {

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);

    }
}

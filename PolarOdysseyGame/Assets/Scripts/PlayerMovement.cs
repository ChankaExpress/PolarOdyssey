using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0) rb.velocity = new Vector3(horizontal * speed, 0, rb.velocity.z);
        if(vertical != 0) rb.velocity = new Vector3(rb.velocity.x, 0, vertical * speed);
    }
}

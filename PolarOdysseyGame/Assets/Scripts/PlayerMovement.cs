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
        Debug.Log("rb: " + rb);
    }

    void Update()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        // if(horizontal != 0) rb.velocity = new Vector3(horizontal * speed, 0, rb.velocity.z);
        // if(vertical != 0) rb.velocity = new Vector3(rb.velocity.x, 0, vertical * speed);


        // transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        // that's bad because it doesn't take into account the camera's rotation
        // better:
        var cameraForward = Camera.main.transform.forward;
        var cameraRight = Camera.main.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        transform.position += cameraForward * Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position += cameraRight * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }
}

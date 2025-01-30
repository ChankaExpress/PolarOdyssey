using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playerMovement : MonoBehaviour
{
    public float speed = 6;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction=new Vector3(horizontalInput,0, verticalInput).normalized;
        controller.Move(direction.normalized * speed * Time.deltaTime);
    }
}


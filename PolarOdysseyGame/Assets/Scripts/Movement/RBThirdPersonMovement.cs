using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RBThirdPersonMovement : MonoBehaviour
{
    

    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform cam;
    [Space]

    [SerializeField] private float speed = 100f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float JumpForce;
    float turnSmoothVelocity;
    
    private Vector3 moveDirection;


    // Initialized for debugging
    Vector3 inputDirection;
    float targetAngle;
    float angle;
    Vector3 moveVector;
    //

    

    // Start is called before the first frame update
    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerBody = GetComponent<Rigidbody>();
        //playerBody.interpolation = RigidbodyInterpolation.None;
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        inputDirection = new Vector3 (horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude > 0.2f)
        {

            Vector3 localForward = inputDirection.z * speed * this.transform.forward;
            Vector3 localRight = inputDirection.x * speed * this.transform.right;
            moveVector = localForward + localRight;

            //targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //moveVector = speed * Time.deltaTime * transform.TransformDirection(moveDirection);

            //angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }

    void FixedUpdate()
    {
        if(inputDirection.magnitude > 0.1f)
            playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
        //(transform.position + moveDirection.normalized * speed * Time.fixedDeltaTime);
    }
}

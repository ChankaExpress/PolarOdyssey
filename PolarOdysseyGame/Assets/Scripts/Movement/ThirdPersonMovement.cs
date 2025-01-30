using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour, IFreezeInputListener
{

    public CharacterController controller;
    public Transform cam; 

    public float speed = 6;

    public float turnSmoothTime = 0.1f;
    [SerializeField] const float GRAVITY = 9.81f;
    public GameObject cameraController;
    float turnSmoothVelocity;
    bool inputFrozen = false;


    // Start is called before the first frame update
    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!inputFrozen) processInput();
    }

    private void processInput(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            moveDirection = moveDirection.normalized * speed;
            moveDirection.y = controller.isGrounded ? 0f : -GRAVITY;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    public void FreezeInput()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraController.SetActive(false);
        inputFrozen = true;
    }

    public void UnfreezeInput()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraController.SetActive(true);
        inputFrozen = false;
    }
}

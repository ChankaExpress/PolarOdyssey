using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity = 2.0f; // Sensitivity of mouse movement
    public float minYAngle = -89f;    // Minimum Y-axis angle
    public float maxYAngle = 89f;     // Maximum Y-axis angle

    private float rotationY = 0f;      // Store the current Y-axis rotation

    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // Horizontal movement
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // Vertical movement

        // Rotate the camera around the Y-axis (horizontal)
        transform.Rotate(0, mouseX, 0);

        // Adjust the vertical rotation
        rotationY -= mouseY;
        rotationY = Mathf.Clamp(rotationY, minYAngle, maxYAngle); // Clamp the vertical rotation
        Camera.main.transform.localEulerAngles = new Vector3(rotationY, 0, 0);

        // Optional: Handle cursor escape to unlock
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
            Cursor.visible = true; // Make the cursor visible
        }
    }
}

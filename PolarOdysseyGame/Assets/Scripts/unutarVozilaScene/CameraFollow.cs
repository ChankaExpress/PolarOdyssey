using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;


public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float zThreshold = 5f; // Adjust how high the player moves before the camera follows
    public float smoothSpeed = 3f; // Adjust for smooth transition

    void Update()
    {
        if (player == null) return;

        // Move camera only when the player reaches above the threshold
        if (player.position.z > transform.position.z - zThreshold)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, player.position.z + zThreshold);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
            //Debug.Log("idem gore");
        }
        else if (player.position.z < transform.position.z + zThreshold)
        {
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y, player.position.z - zThreshold);
            transform.position = Vector3.Lerp(transform.position, newPos, smoothSpeed * Time.deltaTime);
            //Debug.Log("idem dolje");
        }
    }
}


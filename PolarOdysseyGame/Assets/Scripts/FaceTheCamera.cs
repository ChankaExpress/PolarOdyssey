using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTheCamera : MonoBehaviour
{
    Transform cameraTransform;
    Transform spriteTransform;

    void Awake()
    {
        spriteTransform = gameObject.transform;
    }

    void Start()
    {
        cameraTransform = Camera.main.transform;
        // StartCoroutine(faceCamera());
    }

    void Update()
    {
        spriteTransform.LookAt(cameraTransform);
    }

    // IEnumerator faceCamera() {
    //     while(true) {
    //         spriteTransform.LookAt(cameraTransform);
    //         yield return null;
    //     }
    // }
}

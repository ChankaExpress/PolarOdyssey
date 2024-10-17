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
        StartCoroutine(faceCamera());
    }

    void Update()
    {
        
    }

    IEnumerator faceCamera() {
        while(true) {
            Vector3 direction = cameraTransform.position - spriteTransform.position;
            spriteTransform.rotation = Quaternion.LookRotation(direction);
            yield return null;
        }
    }
}

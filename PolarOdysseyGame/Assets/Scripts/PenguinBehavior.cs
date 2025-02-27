using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinBehavior : MonoBehaviour
{
    Transform penguinTransform;
    Transform spriteTransform;
    Transform mainCameraTransform;

    public float speed = 1f;
    public bool isMoving = false;

    void Awake()
    {
        penguinTransform = gameObject.transform;
        mainCameraTransform = Camera.main.transform;
    }

    void Start()
    {
        spriteTransform = penguinTransform.Find("Sprite");
        StartCoroutine(randomBehaviour());
    }

    void Update()
    {
        
    }

    IEnumerator randomBehaviour() {
        while(true) {
            yield return standingStill();
            yield return moveRandomly();
        }
    }

    IEnumerator standingStill() {
        isMoving = false;
        float randomWaitTime = Random.Range(1f, 5f);
        yield return new WaitForSeconds(randomWaitTime);
    }

    IEnumerator moveRandomly() {
        float randomAngle = Random.Range(0, 360);
        float randomMoveTime = Random.Range(1f, 10f);

        //rotation around y axis
        penguinTransform.rotation = Quaternion.Euler(0, randomAngle, 0);
        Vector3 forward = penguinTransform.forward;

        isMoving = true;
        Vector3 toCamera;
        Quaternion targetRotation;

        while(randomMoveTime > 0) {
            penguinTransform.position += speed * Time.deltaTime * forward;

            //bobbing effect
            //should be rotation around toCamera vector
            toCamera = (mainCameraTransform.position - penguinTransform.position).normalized;
            targetRotation = Quaternion.LookRotation(toCamera);
            targetRotation *= Quaternion.Euler(0, 0, 5 * Mathf.Sin(10 * Time.time));
            spriteTransform.rotation = targetRotation;

            spriteTransform.LookAt(spriteTransform.position - spriteTransform.forward, spriteTransform.up);

            randomMoveTime -= Time.deltaTime;
            yield return null;
        }
    }
}

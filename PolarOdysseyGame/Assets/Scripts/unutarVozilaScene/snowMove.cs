using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10;
    public float deadZone = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - (Vector3.back * moveSpeed) * Time.deltaTime;

        if (transform.position.z > deadZone)
        {
            Debug.Log("Snow Deleted");
            Destroy(gameObject);
        }
    }
}

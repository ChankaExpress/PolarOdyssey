using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStrategy : MonoBehaviour, InteractStrategy
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact(GameObject initiator, GameObject receiver)
    {
        Debug.Log("Interacting with PickUpStrategy");
    }
}

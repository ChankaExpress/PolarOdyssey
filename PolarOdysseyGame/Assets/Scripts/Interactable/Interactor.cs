using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void Interact();
    void Interact(Transform interactor);
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 3.5f;

    void Start()
    {
        if(interactorSource == null) interactorSource = this.transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) findAndInteract();
    }

    void findAndInteract()
    {
        if(Physics.Raycast(interactorSource.position, interactorSource.forward, out RaycastHit hit, interactRange))
        {
            Debug.Log("Interacting with " + hit.transform.name);
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable)) interactable.Interact(interactorSource);
        }
    }


}

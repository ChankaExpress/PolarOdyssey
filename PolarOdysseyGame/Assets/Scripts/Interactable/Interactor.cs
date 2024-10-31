using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void Interact();
    void Interact(Interactor interactor);
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 3.5f;
    private bool isInteracting = false;

    void Start()
    {
        if(interactorSource == null) interactorSource = this.transform;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isInteracting) FindAndInteract();
    }

    void FindAndInteract()
    {
        if(Physics.Raycast(interactorSource.position, interactorSource.forward, out RaycastHit hit, interactRange))
        {
            Debug.Log("Interacting with " + hit.transform.name);
            if(hit.collider.gameObject.TryGetComponent(out IInteractable interactable)) interactable.Interact(this);
        }
    }

    public void SetInteracting(bool interacting) {
        this.isInteracting = interacting;
    }
}

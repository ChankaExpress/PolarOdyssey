using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    void Interact(Interactor interactor);
}


/*
this script is meant to be put on the interactor collider
*/
public class Interactor : MonoBehaviour
{
    public Transform interactorPosition;
    public float interactRange = 3.5f;

    private bool isInteracting = false;
    private GameObject lastInteracted;

    private GameObject player;
    private List<GameObject> interactables = new List<GameObject>();

/*
interactor may walk around; once it approaches an interactable, detected by a collision with a trigger
    upon entering the trigger, the interactable is added to the list of possible interactables;
        -> we need a way to choose from this list; 
        probably best to either:
            a) take the angle between the player's front vector and the interactable's position
            b) take the distance from the player's position to interactable's position
            c) take the multiple of a) and b) to make it possible to reach things player is looking at, but are farther away
        option b) will be taken for its simplicity and then changed if it proves inadequate
*/
    void Start()
    {
        if(interactorPosition == null) interactorPosition = this.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput(){
        if(!Input.GetButtonDown("Interact")) return;

        if(!isInteracting) FindAndInteract();
        else lastInteracted.GetComponent<IInteractable>().Interact(this);
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<IInteractable>() == null) return;
        interactables.Remove(other.gameObject);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.GetComponent<IInteractable>() == null) return;
        interactables.Add(other.gameObject);
    }

    void FindAndInteract()
    {
        if(interactables.Count == 0) return;
        float minDistance = float.MaxValue;
        GameObject closestGo = null;

        float distance;
        foreach(GameObject go in interactables) {
            distance = (go.transform.position - player.transform.position).magnitude;
            if(minDistance > distance) {
                minDistance = distance;
                closestGo = go;
            }
        }

        lastInteracted = closestGo;
        closestGo.GetComponent<IInteractable>().Interact(this);
    }

    public void SetInteracting(bool interacting) {
        this.isInteracting = interacting;
    }
}

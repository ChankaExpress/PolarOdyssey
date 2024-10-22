using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// THIS CLASS USES PLAYER TAG
public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;
    public MonoBehaviour strategyObject;

    private InteractStrategy interactStrategy;
    private GameObject player;

    void Start()
    {
        interactStrategy = strategyObject.GetComponent<InteractStrategy>();
    }

    void Awake()
    {
        this.enabled = false;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(!isInteractable) return;

        if(Input.GetKeyDown(KeyCode.E)) Interact();
        
    }

    public void Interact()
    {
        Debug.Log("Interacting with interactable class");
        interactStrategy.Interact(player, this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        this.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        this.enabled = false;
    }
}

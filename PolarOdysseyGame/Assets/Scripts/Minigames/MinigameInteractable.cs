using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInteractable : MonoBehaviour, IInteractable
{
    public GameObject minigamePrefab;
    public Interactor interactor;
    public GameObject minigameInstance;

    public void Interact(Interactor interactor)
    {
        this.interactor = interactor;
        interactor.StartMinigame();
        minigameInstance = Instantiate(minigamePrefab);
        minigameInstance.GetComponentInChildren<Test1Script>().minigameInteractable = this;
    }

    public void EndGame(){
        interactor.EndMinigame();
        this.interactor = null;
        Destroy(minigameInstance);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

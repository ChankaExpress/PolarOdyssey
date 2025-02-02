using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KalendarMinigame : MonoBehaviour, IMinigameLogicController
{
    public MinigameInteractable minigameInteractable;


    void Start(){
        Canvas canvas = this.gameObject.GetComponent<Canvas>();
        Camera mainCamera = Camera.main;
        if(canvas == null || mainCamera == null) {
            Debug.LogWarning("Canvas or MainCamera not found!");
            return;
        }
        canvas.worldCamera = mainCamera;
        canvas.planeDistance = 1f;
    }

    public void setMinigameInteractable(MinigameInteractable val)
    {
        this.minigameInteractable = val;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipersMinigame : MonoBehaviour
{

    private RectTransform colliderRectTransform;
    private Canvas canvas;
    public GameObject persistentCollider;
    private List<SnowScript> snowObjects;

    void Start()
    {
        persistentCollider.SetActive(false);
        colliderRectTransform = persistentCollider.GetComponent<RectTransform>();
        canvas = this.GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;

        generateSnow();
    }

    void generateSnow(){

    }

    void Update()
    {
        processMouse();
    }

    void processMouse(){
        if (Input.GetMouseButtonDown(0))
        {
            persistentCollider.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            MoveColliderToMousePosition();
            pushSnow();
        }
        if (Input.GetMouseButtonUp(0))
        {
            persistentCollider.SetActive(false);
        }
    }

    void pushSnow(){
        foreach(var snow in snowObjects){
            snow.applyBroomEffect(colliderRectTransform.anchoredPosition);
        }
    }

    void MoveColliderToMousePosition()
    {
        Vector2 anchoredPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform, 
            Input.mousePosition, 
            canvas.worldCamera, 
            out anchoredPos);

        colliderRectTransform.anchoredPosition = anchoredPos;
    }

    void OnMousePress(){

    }
}

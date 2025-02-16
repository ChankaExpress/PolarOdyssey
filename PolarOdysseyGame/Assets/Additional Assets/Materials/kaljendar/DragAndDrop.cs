﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 startPosition;
    private Transform startParent;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //Cursor.visible = true;  // Prikaži kursor
        //Cursor.lockState = CursorLockMode.None;  // Omogući slobodno kretanje kursora

    }

    //void Awake()
    //{
    //    rectTransform = GetComponent<RectTransform>();
    //    canvasGroup = GetComponent<CanvasGroup>();
    //    Cursor.visible = true;  // Prikaži kursor
    //    Cursor.lockState = CursorLockMode.None;  // Omogući slobodno kretanje kursora

    //}

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        startPosition = rectTransform.position;
        startParent = transform.parent;
        canvasGroup.alpha = 0.6f; // Umisto 0 da ne nestane
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("dragging");
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (transform.parent == startParent) // Ako nije postavljen na slot, vrati na početnu poziciju
        {
            rectTransform.position = startPosition;
        }
    }
}

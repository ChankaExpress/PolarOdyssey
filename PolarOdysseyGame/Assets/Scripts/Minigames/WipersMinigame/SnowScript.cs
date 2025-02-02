using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowScript : MonoBehaviour
{
    private RectTransform rectTransform;  
    private Rigidbody2D rb2D;      
    public float snowSize = 100f;
    public float broomSize = 1000f;
    private float maxDistanceSquared;
    public float pushVelocity = 0.1f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rb2D = GetComponent<Rigidbody2D>();
        maxDistanceSquared = (snowSize+broomSize) * (snowSize+broomSize);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        // Vector2 pushDirection = (uiElement.position - other.transform.position).normalized;
        // float pushStrength = 5f;  // Adjust the strength of the push

        // uiRb2D.velocity = pushDirection * pushStrength;
    }

    void OnCollisionEnter2D(Collision2D collision2D) {
        Debug.Log("collision enter");
    }

    // Optional: If you want to update the position directly (without physics)
    void Update()
    {
        
    }

    public void applyBroomEffect(Vector2 broomAnchoredPos)
    {
        float dX = rectTransform.anchoredPosition.x - broomAnchoredPos.x;
        float dY = rectTransform.anchoredPosition.y - broomAnchoredPos.y;

        if(Math.Abs(dX) > snowSize + broomSize || Math.Abs(dY) > snowSize + broomSize) return;
        if(dX*dX + dY*dY > maxDistanceSquared) return;

        rb2D.velocity = pushVelocity * new Vector2(dX, dY).normalized;
    }
}
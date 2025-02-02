using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerInZone = false; // Da li je igrač u zoni

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Provjerava da li je objekat igrač
        {
            playerInZone = true;
            Debug.Log("Press F to cook");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Kada igrač napusti zonu
        {
            playerInZone = false;
            //Debug.Log(" ");
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F)) // Ako je igrač u zoni i pritisne F
        {
            Debug.Log("Cooking started!");
        }
    }
}

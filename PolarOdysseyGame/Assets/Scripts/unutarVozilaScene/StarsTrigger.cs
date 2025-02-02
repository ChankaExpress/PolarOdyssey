using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerInZone = false; // Da li je igrač u zoni
    public GameObject minigameCanvas;  // canvas
    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Provjerava da li je objekat igrač
        {
            playerInZone = true;
            Debug.Log("Press F to navigate");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Kada igrač napusti zonu
        {
            playerInZone = false;
            //Debug.Log(" ");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            minigameCanvas.SetActive(false); // Automatski zatvori minigame ako igrač izađe
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.F)) // Ako je igrač u zoni i pritisne F
        {
            Debug.Log("Stars started!");
            Cursor.visible = true;  // Prikaži kursor
            Cursor.lockState = CursorLockMode.None;  // Omogući slobodno kretanje kursora
            minigameCanvas.SetActive(!minigameCanvas.activeSelf); // Uključi/isključi minigame
        }
    }
}

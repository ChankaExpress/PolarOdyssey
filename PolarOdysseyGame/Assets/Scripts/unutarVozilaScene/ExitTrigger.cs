using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerInZone = false; // Da li je igrač u zoni
    public string sceneName;
    public SceneAsset sceneToLoad;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Provjerava da li je objekat igrač
        {
            playerInZone = true;
            Debug.Log("Press F to exit");
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
            Debug.Log("Exited!");
            LoadNewScene();
        }
    }
    void LoadNewScene()
    {
        if (sceneToLoad != null)
        {
            sceneName= sceneToLoad.name;
        }
        SceneManager.LoadScene(sceneName); // Load the specified scene
        Debug.Log("Loading scene: " + sceneName);
    }
}

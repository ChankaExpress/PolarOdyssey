using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EscapeListener2 : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(sceneToLoad);
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;  
        }

    }
}

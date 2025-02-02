using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class EscapeListener : MonoBehaviour
{
    public string sceneToLoad = "MainMenu";

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(sceneToLoad);

    }
}

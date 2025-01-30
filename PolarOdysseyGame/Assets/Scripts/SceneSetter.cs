using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SceneSetter : MonoBehaviour
{
    public string defaultStartScene;

    void Start()
    {
        SceneManager.LoadScene(defaultStartScene);
    }

    void Update()
    {
        
    }
}

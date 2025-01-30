using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class EnterTruck : MonoBehaviour, IInteractable
{
    public string sceneToLoad;

    public void Interact(Interactor interactor)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

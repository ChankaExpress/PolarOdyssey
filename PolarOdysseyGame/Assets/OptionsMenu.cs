using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class VolumeControl : MonoBehaviour
{
    public GameObject music;
    

    public void ChangeVolume(float volume)
    {
        music.GetComponent<AudioSource>().volume = volume;
    }
}
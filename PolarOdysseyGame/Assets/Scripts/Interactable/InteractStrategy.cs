using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractStrategy
{
    void Interact(GameObject initiator, GameObject receiver);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableObject
{
    void Interact(GameObject player);
    string ConfirmMessage { get; }
}
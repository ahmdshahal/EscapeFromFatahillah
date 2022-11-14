using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message displayed to player when looking at an interactable object
    public string promptMessage;

    /// <summary>
    /// This function will be called from our player
    /// </summary>
    public void BaseInteract()
    {
        Interact();
    }

    /// <summary>
    /// We wont have any code written in this function.
    /// This is a template function to be overridden by our subclasses
    /// </summary>
    protected virtual void Interact()
    {
        
    }
}

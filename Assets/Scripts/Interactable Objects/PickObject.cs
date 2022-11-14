using UnityEngine;

public class PickObject : Interactable
{
    /// <summary>
    /// This function is where we will design our interaction using code
    /// </summary>
    protected override void Interact()
    {
        gameObject.SetActive(false);
        Debug.Log("Collected");
    }
}

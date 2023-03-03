using UnityEngine;
using UnityEngine.Serialization;

public class PickObject : Interactable
{
    [SerializeField] private Transform hand;
    [SerializeField] private string pickID;
    [SerializeField] private PickDropSystem pickDropSystem;
    [SerializeField] private bool isKey;
    
    /// <summary>
    /// This function is where we will design our interaction using code
    /// </summary>
    protected override void Interact()
    {
        if (pickDropSystem.isEmpty)
        {
            pickDropSystem.id = pickID;
            pickDropSystem.pickObject = gameObject;
            pickDropSystem.isEmpty = false;
            
            if 
                (isKey)gameObject.SetActive(false);
            else
            {
                transform.position = hand.position; 
                transform.SetParent(hand);
            }
        }
    }
}

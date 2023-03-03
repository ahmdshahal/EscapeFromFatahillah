using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropObject : Interactable
{
    [SerializeField] private PickDropSystem pickDropSystem;
    [SerializeField] private string dropID;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private bool isDoor;
    [SerializeField] private string LoadToScene;
    
    protected override void Interact()
    {
        if (!pickDropSystem.isEmpty)
        {
            if (pickDropSystem.id == dropID)
            {
                pickDropSystem.id = null;
                pickDropSystem.isEmpty = true;

                if (isDoor)
                    SceneManager.LoadScene(LoadToScene);
                else
                {
                    pickDropSystem.pickObject.transform.SetParent(dropPoint);
                    pickDropSystem.pickObject.transform.position = dropPoint.position;
                    pickDropSystem.pickObject.transform.rotation = dropPoint.rotation;
                }
            }
        }
    }
}

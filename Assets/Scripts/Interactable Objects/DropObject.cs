using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropObject : Interactable
{
    [SerializeField] private PickDropSystem pickDropSystem;
    [SerializeField] private MainMenuTask mainMenuTask;
    [SerializeField] private string dropID;
    [SerializeField] private string LoadToScene;
    [SerializeField] private int scene;
    [SerializeField] private Transform dropPoint;
    [SerializeField] private bool isDoor;
    
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

                    pickDropSystem.pickObject.layer = 0;
                }

                switch (scene)
                {
                    case 0:
                        mainMenuTask.PuzzleCompleted();
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    
    public int puzzlePlaced;

    public void PuzzleCompleted()
    {
        puzzlePlaced++;

        if (puzzlePlaced >= 3)
        {
            taskManager.CompleteCurrentTask();
            Debug.Log("Task 1 Completed");
        }
    }
}

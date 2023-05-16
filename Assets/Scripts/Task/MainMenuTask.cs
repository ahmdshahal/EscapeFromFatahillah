using UnityEngine;

public class MainMenuTask : MonoBehaviour
{
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private Interactable drawerLock;
    
    public int puzzlePlaced;

    public void PuzzleCompleted()
    {
        puzzlePlaced++;

        if (puzzlePlaced == 3)
        {
            drawerLock.BaseInteract();
            Debug.Log("Task 1 Completed");

            taskManager.CompleteCurrentTask();
        }
    }
}

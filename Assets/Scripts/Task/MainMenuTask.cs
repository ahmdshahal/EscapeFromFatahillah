using UnityEngine;

public class MainMenuTask : MonoBehaviour
{
    [SerializeField] TaskManager taskManager;
    [SerializeField] Interactable interactable;
    
    public int puzzlePlaced;

    public void PuzzleCompleted()
    {
        puzzlePlaced++;

        if (puzzlePlaced >= 3)
        {
            taskManager.CompleteCurrentTask();
            interactable.BaseInteract();
            Debug.Log("Task 1 Completed");
        }
    }
}

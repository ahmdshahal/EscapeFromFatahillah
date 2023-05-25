using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TaskCompletedCheck : MonoBehaviour
{
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private int taskAmount;
    [SerializeField] private UnityEvent onCompleted;

    public int taskPassed;

    public void PuzzleCompleted()
    {
        taskPassed++;

        if (taskPassed == taskAmount)
        {
            onCompleted.Invoke();
            taskManager.CompleteCurrentTask();
        }
    }
}

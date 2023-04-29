using System;
using System.Collections;
using System.Collections.Generic;using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Serialization;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private HintSystem hintSystem; // instance dari hint system
    [SerializeField] private Material hintMaterial;
    
    public int currentTaskIndex; // index dari tugas yang sedang aktif
    public float hintDuration; // durasi dari hint pada objek hint
    public List<TaskPuzzle> taskPuzzlesList; // list dari semua objek hint pada ruangan

    private void Start()
    {
        if (taskPuzzlesList != null)
        {
            SetHintObjectsByTaskIndex(); // mengatur objek hint pada hint system sesuai dengan tugas yang sedang aktif
        }
    }

    // method untuk menyelesaikan tugas yang sedang aktif
    public void CompleteCurrentTask()
    {
        currentTaskIndex++;
        if (currentTaskIndex < taskPuzzlesList.Count) // jika masih ada tugas berikutnya
        {
            SetHintObjectsByTaskIndex(); // mengatur objek hint pada hint system sesuai dengan tugas berikutnya
        }
    }

    // method untuk mengatur objek hint pada hint system sesuai dengan tugas yang sedang aktif
    private void SetHintObjectsByTaskIndex()
    {
        if (taskPuzzlesList != null)
        {
            List<Renderer> currentTaskHintObjects = new List<Renderer>();
        
            for (int j = 0; j < taskPuzzlesList[currentTaskIndex].hintObjects.Length; j++)
            {
                if (j < taskPuzzlesList[currentTaskIndex].hintObjects.Length)
                {
                    currentTaskHintObjects.Add(taskPuzzlesList[currentTaskIndex].hintObjects[j]); // menambahkan objek hint dari tugas yang sedang aktif
                }
            }

            hintSystem.hintObjects = currentTaskHintObjects.ToArray(); // mengatur objek hint pada hint system sesuai dengan tugas yang sedang aktif
        }
    }

    // method untuk menampilkan hint pada objek hint
    public void ShowHintOnHintObjects()
    {
        if (hintSystem.canShowHint)
        {
            hintSystem.ChangeHintMaterial(hintMaterial, hintDuration); // menampilkan hint pada objek hint
        }
    }
}

[System.Serializable]
public class TaskPuzzle
{
    public Renderer[] hintObjects;
}



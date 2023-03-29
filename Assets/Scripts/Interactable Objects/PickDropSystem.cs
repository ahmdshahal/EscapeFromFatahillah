using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDropSystem : MonoBehaviour
{
    public string id;
    public GameObject pickObject;
    public bool isEmpty;

    private void Start()
    {
        isEmpty = true;
    }
}

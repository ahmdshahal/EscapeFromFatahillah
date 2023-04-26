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

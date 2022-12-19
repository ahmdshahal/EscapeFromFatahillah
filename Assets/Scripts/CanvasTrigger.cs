using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasSejarah;
    [SerializeField]
    private GameObject[] doors;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasSejarah.SetActive(true);

            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].layer = LayerMask.NameToLayer("Interactable");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasSejarah.SetActive(false);
        }
    }
}

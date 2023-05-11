using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField] private GameObject currentScreen;
    [SerializeField] private GameObject nextScreen;

    private void Update()
    {
        if (playerController.isCrouch)
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
        }
    }
}

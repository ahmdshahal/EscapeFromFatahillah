using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpenDetector : MonoBehaviour
{
    [SerializeField] private OpenDrawer openDrawer;
    [SerializeField] private GameObject currentScreen;
    [SerializeField] private GameObject nextScreen;

    private void Update()
    {
        if (openDrawer.isOpen)
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
        }
    }
}

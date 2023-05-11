using UnityEngine;

public class DragDetector : MonoBehaviour
{
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private GameObject currentScreen;
    [SerializeField] private GameObject nextScreen;

    private void Update()
    {
        if(playerInteract.isDrag)
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
        } 
    }
}

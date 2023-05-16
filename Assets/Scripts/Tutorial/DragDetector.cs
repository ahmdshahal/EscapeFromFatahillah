using UnityEngine;

public class DragDetector : MonoBehaviour
{
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private GameObject nextScreen;

    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if(playerInteract.isDrag)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            audioSource.Play();

            taskManager.CompleteCurrentTask();
        } 
    }
}

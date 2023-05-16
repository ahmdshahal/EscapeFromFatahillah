using UnityEngine;

public class DrawerOpenDetector : MonoBehaviour
{
    [SerializeField] private OpenDrawer openDrawer;
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private GameObject[] laci;

    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if (openDrawer.isOpen)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            foreach (var item in laci)
            {
                item.SetActive(true);
            }

            audioSource.Play();
            taskManager.CompleteCurrentTask();
        }
    }
}

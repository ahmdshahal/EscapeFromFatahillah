using UnityEngine;

public class DrawerOpenDetector : MonoBehaviour
{
    [SerializeField] private OpenDrawer openDrawer;
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private GameObject nextScreen;

    private void Update()
    {
        if (openDrawer.isOpen)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            taskManager.CompleteCurrentTask();
        }
    }
}

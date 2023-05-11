using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField] private GameObject nextScreen;

    private void Update()
    {
        if (playerController.isCrouch)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);
        }
    }
}

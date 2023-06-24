using Unity.VisualScripting;
using UnityEngine;

public class HintDetector : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if (inputManager.onFootActions.Hint.triggered)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            audioSource.Play();
            playerController.canCrouch = true;
        }
    }
}

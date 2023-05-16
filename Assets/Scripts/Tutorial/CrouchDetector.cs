using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    [SerializeField] private GameObject nextScreen;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if (playerController.isCrouch)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            audioSource.Play();
        }
    }
}

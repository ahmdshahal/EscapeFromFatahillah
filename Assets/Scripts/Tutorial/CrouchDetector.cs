using UnityEngine;

public class CrouchDetector : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    [SerializeField] private GameObject nextScreen;
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if (inputManager.onFootActions.Crouch.triggered)
        {

            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            audioSource.Play();
        }
    }
}

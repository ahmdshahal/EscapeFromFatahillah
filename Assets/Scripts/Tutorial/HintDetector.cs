using UnityEngine;

public class HintDetector : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private void Update()
    {
        if (inputManager.onFootActions.Hint.triggered)
        {
            gameObject.SetActive(false);
        }
    }
}

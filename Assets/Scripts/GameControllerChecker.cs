using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerChecker : MonoBehaviour
{
    [SerializeField] private Text controllerText;
    
    private bool connected;
    private string sceneName;

    IEnumerator CheckForControllers() {
        while (true) {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0) {
                connected = true;
                controllerText.text = "Connected!";
                Debug.Log("Connected");

                yield return new WaitForSeconds(2f);
                
                LoadMainMenu();
            }
            else if (connected && controllers.Length == 0) {         
                connected = false;
                controllerText.text = "Disconnected!";
                Debug.Log("Disconnected");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    void Awake()
    {
        connected = false;
        StartCoroutine(CheckForControllers());
    }
    
    private void Start()
    {
        sceneName = "Mainmenu";
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI controllerText;
    
    private bool connected;
    private string sceneName;

    IEnumerator CheckForControllers() {
        while (true) {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 0) {
                connected = true;
                controllerText.text = "Koneksi kontroler tersambung!";
                Debug.Log("Connected");

                yield return new WaitForSeconds(2f);
                
                LoadSavedScene();
            }
            else if (connected && controllers.Length == 0) {         
                connected = false;
                controllerText.text = "Koneksi kontroler terputus!";
                Debug.Log("Disconnected");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private void LoadSavedScene()
    {
        if (PlayerPrefs.GetInt("HasLaunched", 0) != 0)
        {
            SaveLoadManager.LoadSceneData();
            Debug.Log("Load Early");
        }
        else
        {
            SceneManager.LoadScene("Mainmenu");
        }
        PlayerPrefs.SetInt("HasLaunched", 1);
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

    private void OnApplicationQuit()
    {
        SaveLoadManager.SaveSceneData();
    }
}

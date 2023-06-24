using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        SaveLoadManager.SaveSceneData();
    }

    private void OnApplicationQuit()
    {
        SaveLoadManager.SaveSceneData();
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SaveLoadManager
{
    private static string theScene;

    static void GetSceneData()
    {
        Scene sceneName = SceneManager.GetActiveScene();
        theScene = sceneName.name;
    }

    static void SetSceneData()
    {
        SceneManager.LoadScene(theScene);
    }

    public static void SaveSceneData()
    {
        GetSceneData();
        PlayerPrefs.SetString("theScene", theScene);
    }

    public static void LoadSceneData()
    {
        theScene = PlayerPrefs.GetString("theScene", theScene);
        SetSceneData();
    }
}

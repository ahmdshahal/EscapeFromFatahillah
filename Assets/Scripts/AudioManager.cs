using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgmFinish;
    [SerializeField] private AudioClip bgmGame;

    private void Awake()
    {
        Scene thisScene = SceneManager.GetActiveScene();

        if(thisScene.name == "Kamar")
        {
            BackgroundMusic.ChangeAudioClip(bgmFinish);
        }

        if(thisScene.name == "Mainmenu")
        {
            BackgroundMusic.ChangeAudioClip(bgmGame);
        }
    }
}

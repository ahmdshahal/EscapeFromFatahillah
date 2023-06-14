using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgmFinish;

    private void Awake()
    {
        Scene thisScene = SceneManager.GetActiveScene();

        if(thisScene.name == "Kamar")
        {
            BackgroundMusic.ChangeAudioClip(bgmFinish);
        }
    }
}

using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static AudioSource bgm;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        bgm = GetComponent<AudioSource>();
    }

    public static void ChangeAudioClip(AudioClip clip)
    {
        bgm.Stop();
        bgm.clip = clip;
        bgm.Play();
    }
}

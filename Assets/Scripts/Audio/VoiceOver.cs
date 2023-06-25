using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceOver : MonoBehaviour
{
    private AudioSource voiceOver;
    private bool isPlay;

    private void Awake()
    {
        voiceOver = GetComponent<AudioSource>();
        isPlay = false;
    }

    public void StartVO(AudioClip voice)
    {
        isPlay = !isPlay;

        if (isPlay)
        {
            voiceOver.Stop();
            voiceOver.PlayOneShot(voice);
        }
        else
        {
            voiceOver.Stop();
        }
    }
}

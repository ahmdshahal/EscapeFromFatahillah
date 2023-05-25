
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitForSecond : MonoBehaviour
{
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private Image durationBar;
    [SerializeField] private float setDuration;
    [SerializeField] private AudioSource audioSource;

    private float duration;
    private bool isCount;

    private void OnEnable()
    {
        duration = 0;
        isCount = true;
    }

    private void Update()
    {
        if(isCount)
            duration += Time.deltaTime;

        durationBar.fillAmount = duration / setDuration;
        if (duration >= setDuration)
        {
            gameObject.SetActive(false);
            isCount = false;

            nextScreen.SetActive(true);
            audioSource.Play();
        }
    }
    private void OnDisable()
    {
        durationBar.fillAmount = 0f;
    }
}

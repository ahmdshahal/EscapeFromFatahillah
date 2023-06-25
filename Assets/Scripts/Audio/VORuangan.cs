using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VORuangan : MonoBehaviour
{
    private AudioSource voiceOver;
    private SphereCollider sphereCollider;

    private void Awake()
    {
        voiceOver = GetComponent<AudioSource>();
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.radius = voiceOver.maxDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceOver.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            voiceOver.Pause();
        }
    }
}

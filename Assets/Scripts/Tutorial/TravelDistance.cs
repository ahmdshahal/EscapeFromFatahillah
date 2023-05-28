using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelDistance : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject nextScreen;
    [SerializeField] private Image distanceBar;
    [SerializeField] private float maxDistance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private bool isSprintChecker;
    [SerializeField] private AudioSource audioSource;

    private float distanceTraveled;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = player.transform.position;
        distanceTraveled = 0f;
    }

    private void Update()
    {
        CountDistanceTraveled();

        //Meng-Update UI untuk menampilkan jarak tempuh
        distanceBar.fillAmount = distanceTraveled / maxDistance;
    }

    private void CountDistanceTraveled()
    {
        //Menghuitung jarak tempuh player
        Vector3 currentPosition = player.transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);

        if (isSprintChecker)
        {
            if (playerController.isSprint)
            {
                distanceTraveled += distance;
                lastPosition = currentPosition;
            }
        }
        else
        {
            distanceTraveled += distance;
            lastPosition = currentPosition;
        }

        DistanceChecker();
    }

    private void DistanceChecker()
    {
        if (distanceBar.fillAmount >= 1)
        {
            gameObject.SetActive(false);
            nextScreen.SetActive(true);

            audioSource.Play();
        }
    }
    private void OnDisable()
    {
        distanceBar.fillAmount = 0f;
        distanceTraveled = 0f;
    }
}

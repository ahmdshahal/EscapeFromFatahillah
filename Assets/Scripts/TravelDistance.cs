using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelDistance : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Image distanceBar;
    [SerializeField] private float maxDistance;
    
    private float distanceTraveled;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = player.transform.position;
        distanceTraveled = 0f;
    }

    private void Update()
    {
        //Menghuitung jarak tempuh player
        Vector3 currentPosition = player.transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);
        distanceTraveled += distance;
        lastPosition = currentPosition;
        
        //Meng-Update UI untuk menampilkan jarak tempuh 
        distanceBar.fillAmount = distanceTraveled / maxDistance;
    }
}

using System;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private Transform emptySpace;
    
    public Vector3 targetPosition;
    public int correctPositionX;
    public int correctPositionY;
    public SliderManager sliderManager;

    private bool onSlide;

    public void SlidePuzzle()
    {
        targetPosition = transform.position;
        var distance = Vector3.Distance(emptySpace.position, targetPosition);

        if (distance <= 20)
        {
            onSlide = true;
            (targetPosition, emptySpace.position) = (emptySpace.position, targetPosition);
            Debug.Log("slided");
        }
    }

    private void Update()
    {
        if (onSlide)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
        }
    }
}

using System;
using UnityEngine;

public class OpenDrawer : Interactable
{
    [SerializeField] private Vector3 targetPosition;

    private Vector3 defaultPosition;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
        
        defaultPosition = transform.localPosition;
        (targetPosition, defaultPosition) = (defaultPosition, targetPosition);
    }

    protected override void Interact()
    {
        isOpen = !isOpen;
        (defaultPosition, targetPosition) = (targetPosition, defaultPosition);

        promptMessage = isOpen ? "Tutup!" : "Buka!";
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 2.5f * Time.deltaTime);
    }
}

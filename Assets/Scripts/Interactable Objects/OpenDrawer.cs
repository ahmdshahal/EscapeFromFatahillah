using System;
using UnityEngine;
using UnityEngine.Serialization;

public class OpenDrawer : Interactable
{
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private bool anythingInside;
    [SerializeField] private PickObject objectIn;
    
    [HideInInspector] public bool isOpen;

    private Vector3 closePosition;

    private void Start()
    {
        isOpen = false;
        
        closePosition = transform.localPosition;
        (openPosition, closePosition) = (closePosition, openPosition);
        
        CheckDrawerIsOpen();
    }

    protected override void Interact()
    {
        isOpen = !isOpen;
        (closePosition, openPosition) = (openPosition, closePosition);
        
        CheckDrawerIsOpen();
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, openPosition, 2.5f * Time.deltaTime);
    }

    private void CheckDrawerIsOpen()
    {
        promptMessage = isOpen ? "Tutup!" : "Buka!";

        if (!anythingInside) return;
        objectIn.promptMessage = isOpen ? "Ambil" : string.Empty;
        objectIn.canPick = isOpen ? true : false;
    }
}

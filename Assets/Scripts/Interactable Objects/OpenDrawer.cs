using System;
using UnityEngine;
using UnityEngine.Serialization;

public class OpenDrawer : Interactable
{
    [SerializeField] private Vector3 openPosition;
    [SerializeField] private bool anythingInside;
    [SerializeField] private PickObject objectIn;
    [SerializeField] private AudioSource drawerSoundOpen;
    [SerializeField] private AudioSource drawerSoundClose;
    
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

        if (isOpen)
            drawerSoundOpen.Play();
        else
            drawerSoundClose.Play();
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, openPosition, 3f * Time.deltaTime);
    }

    private void CheckDrawerIsOpen()
    {
        promptMessage = isOpen ? "Tutup!" : "Buka!";


        if (!anythingInside) return;
        objectIn.promptMessage = isOpen ? "Ambil" : string.Empty;
        objectIn.canPick = isOpen;
    }
}

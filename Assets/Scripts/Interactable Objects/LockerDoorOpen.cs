using System;
using UnityEngine;

public class LockerDoorOpen : Interactable
{
    [SerializeField] private bool anythingInside;
    [SerializeField] private PickObject objectIn;
    [SerializeField] private AudioSource openSound;
    [SerializeField] private AudioSource closeSound;

    private Animator anim;
    private bool isOpen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isOpen = false;
        timer = 1;
    }

    protected override void Interact()
    {
        isOpen = !isOpen;
        
        if (isOpen)
        {
            anim.Play("LockerDoorOpen"); openSound.Play();
        }
        else
        {
            anim.Play("LockerDoorClose"); closeSound.Play();
        }

        CheckLockerIsOpen();
    }

    private void CheckLockerIsOpen()
    {
        promptMessage = isOpen ? "Tutup!" : "Buka!";

        if (!anythingInside) return;
        objectIn.promptMessage = isOpen ? "Ambil" : string.Empty;
        objectIn.canPick = isOpen;
    }
}

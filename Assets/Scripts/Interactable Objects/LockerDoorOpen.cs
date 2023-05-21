using System;
using UnityEngine;

public class LockerDoorOpen : Interactable
{
    [SerializeField] private bool anythingInside;
    [SerializeField] private PickObject objectIn;

    private Animator anim;
    private bool isOpen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isOpen = false;
        timer = 2;
    }

    protected override void Interact()
    {
        isOpen = !isOpen;
        
        if (isOpen)        
            anim.Play("LockerDoorOpen");
        else
            anim.Play("LockerDoorClose");

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

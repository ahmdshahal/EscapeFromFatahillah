using System;
using UnityEngine;

public class LockerDoorOpen : Interactable
{
    private Animator anim;
    private bool isOpen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        promptMessage = "Buka!";
        timer = 2;
    }

    protected override void Interact()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            anim.Play("LockerDoorOpen");
            promptMessage = "Tutup!";
        }
        else
        {
            anim.Play("LockerDoorClose");
            promptMessage = "Buka!";
        }
            
    }
}

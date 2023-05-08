using System;
using UnityEngine;

public class LockerDoorOpen : Interactable
{
    [SerializeField] private bool isDifferentFace;
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
            promptMessage = "Tutup!";
            if (!isDifferentFace)
            {
                anim.Play("LockerDoorOpen");
            }
            else
            {
                anim.Play("AnotherLockerDoorOpen");
            }
        }
        else
        {
            promptMessage = "Buka!";
            if (!isDifferentFace)
            {
                anim.Play("LockerDoorClose");
            }
            else
            {
                anim.Play("AnotherLockerDoorClose");
            }
        }
    }
}

using System;
using UnityEngine;

public class ExplodeCannon : Interactable
{
    public bool canExplode;

    private void Start()
    {
        promptMessage = "Tarik tuas meriam terlebih dahulu!";
        canExplode = false;
    }

    protected override void Interact()
    {
        if (canExplode)
            promptMessage = "Selamat kamu sudah menyelesaikan level 3";
    }

    public void CanExplodeCannon()
    {
        canExplode = true;
        promptMessage = "Ledakkan meriam!";
    }
}

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

    }

    public void CanExplodeCannon()
    {
        canExplode = true;
        promptMessage = "Ledakkan meriam!";
    }
}

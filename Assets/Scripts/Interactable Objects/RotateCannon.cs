using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : Interactable
{
    [SerializeField]
    private Transform cannon;

    protected override void Interact()
    {
        Vector3 cannonRotationY = new(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z);
        int layerDefault = LayerMask.NameToLayer("Default");

        cannon.Rotate(cannonRotationY);
        gameObject.layer = layerDefault;
        GreenUnlocker.redButtonPush++;
    }
}

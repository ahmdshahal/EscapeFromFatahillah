using System;
using UnityEngine;

public class RotateCannon : Interactable
{
    [SerializeField] private Transform cannon;
    [SerializeField] private int maxButtonPress;

    private Vector3 yCannonRotation;
    private Quaternion targetRotation;
    private float speedRotate;
    private int layerDefault;
    private int buttonPress;

    private void Start()
    {
        /*var rotation = cannon.transform.rotation;
        yCannonRotation = new Vector3(rotation.x, rotation.y + 90, rotation.z);
        Debug.Log(rotation.y);*/
        speedRotate = 5 * Time.deltaTime;
        layerDefault = LayerMask.NameToLayer("Default");
    }

    protected override void Interact()
    {
        //cannon.Rotate(yCannonRotation, Space.Self);
        Quaternion rotation = cannon.transform.rotation;
        targetRotation = Quaternion.Euler(0, rotation.eulerAngles.y + 90, 0);
        Debug.Log(rotation.eulerAngles.y);
        Debug.Log(targetRotation);
        gameObject.layer = layerDefault;
        
        ButtonPressChecker();
    }

    private void Update()
    {
        cannon.transform.rotation = Quaternion.Lerp(cannon.transform.rotation, targetRotation, speedRotate);
    }

    private void ButtonPressChecker()
    {
        buttonPress++;

        if (buttonPress == maxButtonPress)
        {
            //Masukkan fungsi
        }
    }
}

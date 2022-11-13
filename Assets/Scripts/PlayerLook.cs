using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    private float yRotation = 0f;

    public Camera cam;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        //Calculate camera rotation for looking up and down;
        yRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        yRotation = Mathf.Clamp(yRotation, -80f, 80f);

        //Apply this to out camera transform
        cam.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

        //Rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}

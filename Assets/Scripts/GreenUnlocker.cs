using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenUnlocker : MonoBehaviour
{
    public static int redButtonPush;
    [SerializeField]
    private GameObject greenDoor;

    // Update is called once per frame
    void Update()
    {
        if(redButtonPush == 3)
        {
            greenDoor.layer = LayerMask.NameToLayer("Interactable");
        }
    }
}

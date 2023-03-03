using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject timerUI;
    [SerializeField]
    private TMP_Text timerText;
    [SerializeField]
    private Image imgTimer;
    [SerializeField]
    private float timerValue;

    private float countTime;
    private bool isCount;

    private Camera cam;
    private PlayerUI playerUI;
    private InputManager inputManager;

    void Awake()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI= GetComponent<PlayerUI>();
        inputManager= GetComponent<InputManager>();
    }

    void Update()
    {
        InteractObject();
    }

    void InteractObject()
    {
        //Create a ray at the center of the camera, shooting outwards.
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (interactable.timer == 0)
                {
                    if (inputManager.onFootActions.Interact.triggered) interactable.BaseInteract();
                    return;
                }
                else
                {
                    if (inputManager.onFootActions.Interact.IsPressed())
                    {
                        timerText.text = timerValue.ToString("0.0");
                        if (timerValue <= 0)
                        {
                            timerValue = interactable.timer;
                            countTime = interactable.timer;
                        }
                        else
                        {
                            isCount = true;
                            timerUI.SetActive(true);
                            if (isCount)
                            {
                                timerValue -= Time.deltaTime;
                                imgTimer.fillAmount = timerValue / countTime;
                                if (timerValue <= 0)
                                {
                                    interactable.BaseInteract();
                                    isCount = false;
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        isCount = false;
                        timerUI.SetActive(false);
                        timerValue = 0;
                    }
                }
                
            }
        }
        else
        {
            isCount = false;
            timerUI.SetActive(false);
            playerUI.UpdateText(string.Empty);
            timerValue = 0;
        }

    }
}

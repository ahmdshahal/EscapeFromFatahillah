using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text prompText;

    public void UpdateText(string prompMessage)
    {
        prompText.text = prompMessage;
    }
}

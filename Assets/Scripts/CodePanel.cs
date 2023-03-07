using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodePanel : MonoBehaviour 
{
	[SerializeField]
	private TextMeshProUGUI codeText;
	private string codeTextValue = "";

	public Animator anim;
	public GameObject numPanel;
	public GameObject puzzle;
	public AudioSource audioSource;

	void Update () 
	{
		codeText.text = codeTextValue;

		//Gaperlu backspace, enter buat ngereset sekaligus ngecek
		if (codeTextValue.Length == 4)
		{
			if (codeTextValue == "1837")
			{
				anim.SetBool("Active", true);
                puzzle.SetActive(true);
                numPanel.SetActive(false);
                codeTextValue = "";
            }
			else
			{
				codeTextValue = "";
				audioSource.Play();
			}
		}
	}

	public void AddDigit(string digit)
	{
		codeTextValue += digit;
	}

}

using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class CodePanel : MonoBehaviour 
{
	[SerializeField] private TextMeshProUGUI inputNum;
	[SerializeField] private string rightCode;
	[SerializeField] private AudioSource rightSound, wrongSound, numPress;

	private string codeTextValue;

	private void Start()
	{
		codeTextValue = null;
		inputNum.text = codeTextValue;
	}

	public void AddNumCode(string num)
	{
		codeTextValue += num;
		inputNum.text = codeTextValue;
		numPress.Play();
		
		CheckCorrectCode();
	}

	private void CheckCorrectCode()
	{
		//Gaperlu backspace, enter buat ngereset sekaligus ngecek
		if (codeTextValue.Length == 3)
		{
			if (codeTextValue == rightCode)
			{
				codeTextValue = null;
                
				rightSound.Play();
			}
			else
			{
				codeTextValue = null;
				
				wrongSound.Play();
			}
		}
	}
}

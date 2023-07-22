using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CodePanel : MonoBehaviour 
{
	[SerializeField] private TextMeshProUGUI inputNum;
	[SerializeField] private string rightCode;
	[SerializeField] private AudioSource rightSound, wrongSound, numPress;
	[SerializeField] private AddNumCode[] numButtons;
	[SerializeField] private UnityEvent onPassed;
	
	[HideInInspector] public bool canInput;

	private string codeTextValue;

	private void Start()
	{
		canInput = true;
		codeTextValue = null;
		inputNum.text = codeTextValue;
	}

	public void AddNumCode(string num)
	{
		if (canInput)
		{
			codeTextValue += num;
			inputNum.text = codeTextValue;
			numPress.Play();
		
			CheckCorrectCode();
		}
	}

	private void CheckCorrectCode()
	{
		if (codeTextValue.Length >= rightCode.Length)
		{
			StartCoroutine(CheckCorrectCodeCoroutine());
		}
	}

	private IEnumerator CheckCorrectCodeCoroutine()
	{
		yield return new WaitForSeconds(1);
		
		if (codeTextValue == rightCode)
		{
			rightSound.Play();
			canInput = false;
			foreach (var num in numButtons)
			{
				num.promptMessage = "Kode yang dimasukkan sudah benar";
			}

			onPassed.Invoke();
		}
		else
		{
			codeTextValue = string.Empty;
			inputNum.text = codeTextValue;
			wrongSound.Play();
		}
	}
}

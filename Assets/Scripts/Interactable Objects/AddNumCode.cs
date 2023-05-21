using UnityEngine;

public class AddNumCode : Interactable
{
    [SerializeField] private CodePanel codePanel;
    [SerializeField] private string num;
    
    protected override void Interact()
    {
        codePanel.AddNumCode(num);
    }
}

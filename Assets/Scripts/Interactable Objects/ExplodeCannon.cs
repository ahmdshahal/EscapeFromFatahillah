using System;
using System.Collections;
using UnityEngine;

public class ExplodeCannon : Interactable
{
    public bool canExplode;

    [SerializeField] private MenuController controller;
    [SerializeField] private Animator[] lightAnim;
    [SerializeField] private AudioSource dangerSound;

    private void Start()
    {
        promptMessage = "Tarik tuas meriam terlebih dahulu!";
        canExplode = false;
    }

    protected override void Interact()
    {
        if (canExplode)
        {
            gameObject.layer = 0;
            foreach (var anim in lightAnim)
            {
                anim.Play("Danger");
            }
            dangerSound.Play();

            StartCoroutine(ExplodeTheCannon());
        }
    }

    public void CanExplodeCannon()
    {
        canExplode = true;
        promptMessage = "Ledakkan meriam!";
    }

    private IEnumerator ExplodeTheCannon()
    {

        yield return new WaitForSeconds(5);

        controller.GoToScene("Kamar");
    }
}

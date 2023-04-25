using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public Renderer[] hintObjects; // list dari semua objek hint
    private Material[] originalMaterials; // list dari material asli dari setiap objek hint

    private void Start()
    {
        originalMaterials = new Material[hintObjects.Length];
        for (int i = 0; i < hintObjects.Length; i++)
        {
            originalMaterials[i] = hintObjects[i].material; // menyimpan material asli dari setiap objek hint
        }
    }

    // method untuk mengubah material dari semua objek hint
    public void ChangeHintMaterial(Material hintMaterial, float duration)
    {
        StartCoroutine(ChangeHintMaterialCoroutine(hintMaterial, duration));
    }

    private IEnumerator ChangeHintMaterialCoroutine(Material hintMaterial, float duration)
    {
        foreach (Renderer hintObject in hintObjects)
        {
            hintObject.material = hintMaterial; // mengubah material dari objek hint
        }

        yield return new WaitForSeconds(duration);

        for (int i = 0; i < hintObjects.Length; i++)
        {
            hintObjects[i].material = originalMaterials[i]; // mengembalikan material objek hint ke material aslinya
        }
    }
}

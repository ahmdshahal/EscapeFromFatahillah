using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public Renderer[] hintObjects; // list dari semua objek hint
    public bool canShowHint;
    private Dictionary<Renderer, Material[]> originalMaterials; // dictionary dari material asli dari setiap objek hint

    private void Start()
    {
        canShowHint = true;
    }

    /// <summary>
    /// Coroutine untuk mengubah material object menjadi hintMaterial selama duration detik
    /// </summary>
    /// <param name="hintMaterial">Material hint yang akan digunakan</param>
    /// <param name="duration">Durasi mengubah material</param>
    public void ChangeHintMaterial(Material hintMaterial, float duration)
    {
        StartCoroutine(ChangeHintMaterialCoroutine(hintMaterial, duration));
    }
    
    // method untuk mengubah material dari semua objek hint
    private IEnumerator ChangeHintMaterialCoroutine(Material hintMaterial, float duration)
    {
        canShowHint = false;
        originalMaterials = new Dictionary<Renderer, Material[]>();
        foreach (Renderer hintObject in hintObjects)
        {
            Material[] materials = hintObject.materials;
            originalMaterials.Add(hintObject, materials); // menyimpan material asli dari setiap objek hint
        }
        
        foreach (Renderer hintObject in hintObjects)
        {
            Material[] materials = hintObject.materials;
            originalMaterials.TryGetValue(hintObject, out Material[] originalMaterial); // mengambil material asli dari dictionary
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = hintMaterial;
            }
            hintObject.materials = materials;
        }

        yield return new WaitForSeconds(duration);

        foreach (Renderer hintObject in hintObjects)
        {
            Material[] materials = hintObject.materials;
            originalMaterials.TryGetValue(hintObject, out Material[] originalMaterial); // mengambil material asli dari dictionary
            for (int j = 0; j < materials.Length; j++)
                if (originalMaterial != null) materials[j] = originalMaterial[j];
            hintObject.materials = materials;
        }

        canShowHint = true;
    }
}

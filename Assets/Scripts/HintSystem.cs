using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    public Renderer[] hintObjects; // list dari semua objek hint
    public Renderer[] otherObjects; // list dari semua objek lain selain hint objects
    public bool canShowHint;

    private Dictionary<Renderer, Material[]> originalMaterials; // dictionary dari material asli dari setiap objek hint
    private Dictionary<Renderer, Material[]> originalOtherMaterials; // dictionary dari material asli dari setiap objek hint

    private void Start()
    {
        canShowHint = true;
    }

    private void SaveOriginalMaterials()
    {
        originalMaterials = new Dictionary<Renderer, Material[]>();
        foreach (Renderer hintObject in hintObjects)
        {
            Material[] materials = hintObject.materials;
            originalMaterials.Add(hintObject, materials); // menyimpan material asli dari setiap objek hint
        }
        
        originalOtherMaterials = new Dictionary<Renderer, Material[]>();
        foreach (Renderer otherObject in otherObjects)
        {
            Material[] materials = otherObject.materials;
            originalOtherMaterials.Add(otherObject, materials); // menyimpan material asli dari setiap objek selain hint
        }
    }

    /// <summary>
    /// Coroutine untuk mengubah material object menjadi hintMaterial selama duration detik
    /// </summary>
    /// <param name="hintMaterial">Material hint yang akan digunakan</param>
    /// <param name="notHintMaterial">Material selain hint yang akan digunakan</param>
    /// <param name="duration">Durasi mengubah material</param>
    public void ChangeHintMaterial(Material hintMaterial,Material notHintMaterial, float duration)
    {
        StartCoroutine(ChangeHintMaterialCoroutine(hintMaterial, notHintMaterial,duration));
    }
    
    // method untuk mengubah material dari semua objek hint
    private IEnumerator ChangeHintMaterialCoroutine(Material hintMaterial,Material notHintMaterial, float duration)
    {
        canShowHint = false;

        SaveOriginalMaterials();

        //Mengganti material asli hintObjects menjadi hint material
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

        //Mengganti material asli other Objects menjadi not hint material
        foreach (Renderer otherObject in otherObjects)
        {
            Material[] materials = otherObject.materials;
            this.originalOtherMaterials.TryGetValue(otherObject, out Material[] originalOtherMaterials); // mengambil material asli dari dictionary
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = notHintMaterial;
            }
            otherObject.materials = materials;
        }

        yield return new WaitForSeconds(duration);

        ReturnOriginalMaterials(hintMaterial, notHintMaterial);

        canShowHint = true;
    }

    public void ReturnOriginalMaterials(Material hintMaterial, Material notHintMaterial)
    {
        //Mengganti hint material hintObjects menjadi material aslinya
        foreach (Renderer hintObject in hintObjects)
        {
            Material[] materials = hintObject.materials;
            originalMaterials.TryGetValue(hintObject, out Material[] originalMaterial); // mengambil material asli dari dictionary
            for (int j = 0; j < materials.Length; j++)
                if (originalMaterial != null) materials[j] = originalMaterial[j];
            hintObject.materials = materials;
        }

        //Mengganti hint material otherObjects menjadi material aslinya
        foreach (Renderer otherObject in otherObjects)
        {
            Material[] materials = otherObject.materials;
            originalOtherMaterials.TryGetValue(otherObject, out Material[] originalOtherMaterial); // mengambil material asli dari dictionary
            for (int j = 0; j < materials.Length; j++)
                if (originalOtherMaterial != null) materials[j] = originalOtherMaterial[j];
            otherObject.materials = materials;
        }
    }
}

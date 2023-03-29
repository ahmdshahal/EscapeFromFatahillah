using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] interactObjects;
    [SerializeField] private Material hintMat;
    [SerializeField] private float time;
    
    private List<Material> normalMat = new();

    private void Awake()
    {
        foreach (var t in interactObjects)
        {
            var rend = t.GetComponent<Renderer>();
            normalMat.Add(rend.material);
        }
    }

    public IEnumerator HintInstinct()
    {
        foreach (var o in interactObjects)
        {
            var rend = o.GetComponent<Renderer>();
            rend.material = hintMat;
        }

        yield return new WaitForSeconds(time);

        for (var i = 0; i < interactObjects.Length; i++)
        {
            var rend = interactObjects[i].GetComponent<Renderer>();
            rend.material = normalMat[i];
        }
    }
}

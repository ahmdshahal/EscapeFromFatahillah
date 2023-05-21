using UnityEngine;
using UnityEngine.Events;

public class DropObject : Interactable
{
    [SerializeField] private PickDropSystem pickDropSystem; // variabel untuk mengambil data dari PickDropSystem
    [SerializeField] private string dropID; // id objek yang akan di-drop
    [SerializeField] private Transform dropPoint; // titik drop objek
    [SerializeField] private bool isEventOnly; // apakah objek yang di-drop adalah pintu
    [SerializeField] private UnityEvent onPassed;
    
    // method yang akan dijalankan ketika objek di-interaksi
    protected override void Interact()
    {
        if (!pickDropSystem.isEmpty && pickDropSystem.id == dropID) // cek apakah ada objek yang sedang dipegang
        {
            pickDropSystem.id = string.Empty; // reset id objek yang dipegang di PickDropSystem
            pickDropSystem.isEmpty = true; // set status di PickDropSystem menjadi kosong

            if (isEventOnly) // jika objek yang di-drop adalah pintu
                onPassed.Invoke();
            else // jika objek yang di-drop bukan pintu
            {
                pickDropSystem.pickObject.transform.SetParent(dropPoint); // set parent dari objek yang dipegang ke titik drop
                pickDropSystem.pickObject.transform.position = dropPoint.position; // set posisi objek yang dipegang ke posisi titik drop
                pickDropSystem.pickObject.transform.rotation = dropPoint.rotation; // set rotasi objek yang dipegang ke rotasi titik drop

                pickDropSystem.pickObject.layer = 0; // set layer objek yang di-drop menjadi default
                onPassed.Invoke();
            }
        }
    }
}

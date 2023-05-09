using UnityEngine;
using UnityEngine.Serialization;

public class PickObject : Interactable
{
    [SerializeField] private Vector3 targetRotation; // Menyimpan rotasi yang diinginkan
    [SerializeField] private Transform hand;
    [SerializeField] private string pickID;
    [SerializeField] private PickDropSystem pickDropSystem;
    [SerializeField] private bool isKey;
    
    /// <summary>
    /// This function is where we will design our interaction using code
    /// </summary>
    protected override void Interact()
    {
        // Cek apakah tangan pemain kosong
        if (pickDropSystem.isEmpty)
        {
            // Jika tangan kosong, ambil objek dan tampilkan di tangan pemain
            pickDropSystem.id = pickID;
            pickDropSystem.pickObject = gameObject;
            pickDropSystem.isEmpty = false;
            
            if (isKey)
            {
                // Jika objek yang diambil adalah kunci, nonaktifkan objek
                gameObject.SetActive(false);
            }
            else
            {
                // Jika bukan kunci, letakkan objek di tangan pemain
                transform.position = hand.position;
                transform.rotation = Quaternion.Euler(targetRotation); // Mengatur rotasi objek
                transform.SetParent(hand);
            }
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class DropObject : Interactable
{
    [SerializeField] private PickDropSystem pickDropSystem; // variabel untuk mengambil data dari PickDropSystem
    [SerializeField] private MainMenuTask mainMenuTask; // variabel untuk mengambil data dari MainMenuTask
    [SerializeField] private string dropID; // id objek yang akan di-drop
    [SerializeField] private string LoadToScene; // nama scene yang akan dimuat
    [SerializeField] private int scene; // nomor scene
    [SerializeField] private Transform dropPoint; // titik drop objek
    [SerializeField] private bool isDoor; // apakah objek yang di-drop adalah pintu
    
    // method yang akan dijalankan ketika objek di-interaksi
    protected override void Interact()
    {
        if (!pickDropSystem.isEmpty) // cek apakah ada objek yang sedang dipegang
        {
            if (pickDropSystem.id == dropID) // cek apakah objek yang sedang dipegang cocok dengan id yang diperlukan untuk melakukan drop
            {
                pickDropSystem.id = null; // reset id objek yang dipegang di PickDropSystem
                pickDropSystem.isEmpty = true; // set status di PickDropSystem menjadi kosong

                if (isDoor) // jika objek yang di-drop adalah pintu
                    SceneManager.LoadScene(LoadToScene); // load scene yang sudah ditentukan

                else // jika objek yang di-drop bukan pintu
                {
                    pickDropSystem.pickObject.transform.SetParent(dropPoint); // set parent dari objek yang dipegang ke titik drop
                    pickDropSystem.pickObject.transform.position = dropPoint.position; // set posisi objek yang dipegang ke posisi titik drop
                    pickDropSystem.pickObject.transform.rotation = dropPoint.rotation; // set rotasi objek yang dipegang ke rotasi titik drop

                    pickDropSystem.pickObject.layer = 0; // set layer objek yang di-drop menjadi default
                }

                switch (scene) // cek nomor scene saat ini
                {
                    case 0: // jika nomor scene adalah 0
                        mainMenuTask.PuzzleCompleted(); // jalankan method PuzzleCompleted() pada MainMenuTask
                        break;
                    case 1:
                        
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        
                        break;
                }
            }
        }
    }
}

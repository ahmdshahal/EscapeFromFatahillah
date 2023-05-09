using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private LayerMask dragMask;

    [SerializeField] private GameObject timerUI;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Image imgTimer;
    [SerializeField] private float timerValue;
    [SerializeField] private Transform dragHand;

    private float countTime;

    private Camera cam;
    private PlayerUI playerUI;
    private InputManager inputManager;

    void Awake()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        InteractObject();
    }

    void InteractObject()
    {
        // Membuat ray dari posisi kamera ke arah depan
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance); // Debug draw ray
        
        // Melakukan raycast dan mendapatkan informasi hit
        if (Physics.Raycast(ray, out RaycastHit hit, distance, mask))
        {
            // Jika object yang terkena raycast memiliki komponen Interactable, maka lakukan aksi
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                playerUI.UpdateText(interactable.promptMessage); // Update text di UI
    
                // Jika timer dari Interactable bernilai 0, langsung lakukan aksi
                if (interactable.timer == 0)
                {
                    if (inputManager.onFootActions.Interact.triggered) interactable.BaseInteract();
                    return;
                }
                else // Jika tidak, tampilkan UI timer dan hitung mundur
                {
                    // Jika tombol interaksi ditekan
                    if (inputManager.onFootActions.Interact.IsPressed())
                    {
                        timerText.text = timerValue.ToString("0.0"); // Update teks timer
                        if (timerValue <= 0) // Jika timer belum diatur, atur nilai timer dan waktu hitung mundur
                        {
                            timerValue = interactable.timer;
                            countTime = interactable.timer;
                        }
                        else // Jika timer sudah diatur, hitung mundur
                        {
                            timerUI.SetActive(true); // Aktifkan UI timer
                            timerValue -= Time.deltaTime;
                            imgTimer.fillAmount = timerValue / countTime;
                            if (timerValue <= 0) // Jika waktu hitung mundur sudah habis, lakukan aksi
                            {
                                interactable.BaseInteract();
                                return;
                            }
                        }
                    }
                    else // Jika tombol interaksi tidak ditekan, hentikan hitung mundur
                    {
                        timerUI.SetActive(false); // Matikan UI timer
                        timerValue = 0;
                    }
                }
            }
        }
        else // Jika raycast tidak mengenai object, hentikan hitung mundur dan matikan UI timer
        {
            timerUI.SetActive(false);
            playerUI.UpdateText(string.Empty); // Kosongkan teks di UI
            timerValue = 0;
        }
    
        // Jika raycast mengenai object yang dapat digeser dan tombol interaksi ditekan, geser object
        if (Physics.Raycast(ray, out RaycastHit dragHit, distance, dragMask))
        {
            playerUI.UpdateText("Geser");
            if (inputManager.onFootActions.Interact.IsPressed())
                dragHit.transform.SetParent(dragHand.transform);
            else
                dragHand.DetachChildren(); // Lepaskan object yang digeser dari tangan

        }
        else // Jika tidak, lepaskan object yang digeser dari tangan
        {
            playerUI.UpdateText(string.Empty);
            dragHand.DetachChildren();
        }
    }
}

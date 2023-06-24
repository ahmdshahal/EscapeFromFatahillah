using UnityEngine;

public class NextLevelTrigger : Interactable
{
    [SerializeField] private MenuController menuController;
    [SerializeField] private string sceneWantToGo;

    protected override void Interact()
    {
        //menuController.GoToScene(sceneWantToGo);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collide with Player");
            menuController.GoToScene(sceneWantToGo);
        }
    }
}

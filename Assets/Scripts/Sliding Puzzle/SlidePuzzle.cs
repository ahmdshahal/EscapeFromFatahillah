using UnityEngine;

public class SlidePuzzle : Interactable
{
    [SerializeField] SlidePuzzleManager sliderManager;
    public Vector3 correctPosition;
    public Vector3 targetPosition;
    public bool inRightPlace;

    private SlidePuzzle slidePuzzle;
    
    private void Awake()
    {
        slidePuzzle = GetComponent<SlidePuzzle>();
        targetPosition = transform.localPosition;
        correctPosition = targetPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, 5f * Time.deltaTime);
    }

    protected override void Interact()
    {
        Slide();
    }

    public void Slide()
    {
        sliderManager.SlidePuzzle(slidePuzzle);
    }
}

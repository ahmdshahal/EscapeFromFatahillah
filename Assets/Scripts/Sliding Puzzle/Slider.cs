using UnityEngine;

public class Slider : MonoBehaviour
{
    public Vector3 correctPosition;
    public Vector3 targetPosition;
    public bool inRightPlace;
    
    private void Awake()
    {
        targetPosition = transform.localPosition;
        correctPosition = targetPosition;
    }

    private void Update()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, targetPosition, 0.05f);
    }
}

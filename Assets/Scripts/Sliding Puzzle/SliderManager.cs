using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private RectTransform emptySpace;
    [SerializeField] private Transform[] tiles;
    [SerializeField] private Button[] tilesPuzzle;
    [SerializeField] private int correctPuzzle;

    private void Start()
    {
        Shuffle();
    }

    public void SlidePuzzle(Slider button)
    {
        //Check position distance between empty space and clicked button
        var distance = Vector3.Distance(emptySpace.localPosition, button.targetPosition);
        
        if (distance <= 55)
        {
            //Swap Position clicked Button and empty space 
            (button.targetPosition, emptySpace.localPosition) = (emptySpace.localPosition, button.targetPosition);
            
            //Check Correct Puzzle
            if (button.correctPosition == button.targetPosition)
            {
                correctPuzzle++;
                button.inRightPlace = true;
            }
            else if(button.correctPosition != button.targetPosition && button.inRightPlace)
            {
                correctPuzzle--;
                button.inRightPlace = false;
            }
            
            //Check The Puzzle is solved
            PuzzleSolvedChecker();
        }
    }

    private void PuzzleSolvedChecker()
    {
        if (correctPuzzle == tiles.Length - 1)
        {
            Debug.Log("Solved");
        }
    }

    private void Shuffle()
    {
        //Looping 500x to shuffle the puzzle
        for (int i = 0; i < 500; i++)
        {
            //Make random tile button index and click the tile button
            int randomIndex = Random.Range(0, tilesPuzzle.Length);
            Debug.Log(randomIndex);
            tilesPuzzle[randomIndex].onClick.Invoke();
        }
    }
}


using UnityEngine;
using Random = UnityEngine.Random;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] private Transform emptySpace;
    [SerializeField] private Transform[] tiles;
    [SerializeField] private SlidePuzzle[] tilesPuzzle;
    [SerializeField] private int correctPuzzle;
    [SerializeField] private Renderer lukisan;
    [SerializeField] private Material materialLukisan;

    private float minDistance;

    private void Start()
    {
        minDistance = Vector3.Distance(tilesPuzzle[0].correctPosition, tilesPuzzle[1].correctPosition);
        Debug.Log(("Min Distance: " + minDistance));
        Shuffle();
    }

    public void SlidePuzzle(SlidePuzzle puzzle)
    {
        //Check position distance between empty space and clicked button
        var distance = Vector3.Distance(emptySpace.localPosition, puzzle.targetPosition);
        
        if (distance <= minDistance + .1f)
        {
            //Swap Position clicked Button and empty space 
            (puzzle.targetPosition, emptySpace.localPosition) = (emptySpace.localPosition, puzzle.targetPosition);
            
            //Check Correct Puzzle
            if (puzzle.correctPosition == puzzle.targetPosition)
            {
                correctPuzzle++;
                puzzle.inRightPlace = true;
            }
            else if(puzzle.correctPosition != puzzle.targetPosition && puzzle.inRightPlace)
            {
                correctPuzzle--;
                puzzle.inRightPlace = false;
            }
            
            //Check The Puzzle is solved
            PuzzleSolvedCheck();
        }
    }

    private void PuzzleSolvedCheck()
    {
        if (correctPuzzle == tiles.Length - 1)
        {
            lukisan.material = materialLukisan;
            foreach (var puzzle in tilesPuzzle)
            {
                puzzle.promptMessage = "Perhatikan lukisan!";
            }
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
            tilesPuzzle[randomIndex].Slide();
        }
    }
}


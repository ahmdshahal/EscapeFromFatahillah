using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class SlidePuzzleManager : MonoBehaviour
{
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private Transform emptySpace;
    [SerializeField] private SlidePuzzle[] tilesPuzzle;
    [SerializeField] private int correctPuzzle;
    [SerializeField] private GameObject locker, wall, lukisan;

    private float minDistance;
    private bool isSolved;

    private void Start()
    {
        isSolved = false;
        minDistance = Vector3.Distance(tilesPuzzle[0].correctPosition, tilesPuzzle[1].correctPosition) + .1f;
        Shuffle();
    }

    public void SlidePuzzle(SlidePuzzle puzzle)
    {
        //Check position distance between empty space and clicked button
        var distance = Vector3.Distance(emptySpace.localPosition, puzzle.targetPosition);
        
        if (distance <= minDistance && !isSolved)
        {
            //Swap Position clicked Button and empty space 
            (puzzle.targetPosition, emptySpace.localPosition) = (emptySpace.localPosition, puzzle.targetPosition);
            
            //Check Correct Puzzle
            CheckCorrectPuzzle(puzzle);
            
            //Check The Puzzle is solved
            PuzzleSolvedCheck();
        }
    }

    private void CheckCorrectPuzzle(SlidePuzzle puzzle)
    {
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
    }

    private void PuzzleSolvedCheck()
    {
        if (correctPuzzle == tilesPuzzle.Length)
        {
            isSolved = true;

            foreach (var puzzle in tilesPuzzle)
            {
                puzzle.promptMessage = "Perhatikan tembok di samping!";
            }
            wall.SetActive(false);
            lukisan.SetActive(true);
            locker.SetActive(true);
            
            taskManager.CompleteCurrentTask();
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


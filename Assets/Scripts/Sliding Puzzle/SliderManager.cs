using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SliderManager : MonoBehaviour
{
    [SerializeField] private Transform[] tiles;
    
    public int correctPuzzle;

    private void Start()
    {
        Shuffle();
    }

    public void Shuffle()
    {
        for (int j = 0; j < 10; j++)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                int randomIndex = Random.Range(0, tiles.Length);
                var distance = Vector3.Distance(tiles[i].position, tiles[randomIndex].position);
            
                if (distance <= 20)
                {
                    (tiles[i].transform.position, tiles[randomIndex].transform.position) = (tiles[randomIndex].transform.position, tiles[i].transform.position);
                }
            }
        }
    }

    private void Update()
    {
        if (correctPuzzle == 8)
        {
            Debug.Log("Solved!");
        }
    }
}


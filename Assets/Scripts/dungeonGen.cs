using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class dungeonGen : MonoBehaviour
{
    [SerializeField]
    protected Vector2Int startPos = Vector2Int.zero;

    [SerializeField]
    private int iterations = 10;
    [SerializeField]
    public int length = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    [SerializeField]
    private tilemapVisualiser tilemapVisualiser;

    public void generate()
    {
        HashSet<Vector2Int> floorPositions = genRand();
        tilemapVisualiser.Clear();
        tilemapVisualiser.paintFloorTiles(floorPositions);
    }
    private HashSet<Vector2Int> genRand()
    {
        var currentPos = startPos;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();

        for (int i = 0; i < iterations; i++)
        {
            var path = randGenerationAlgorithm.randomWalk(currentPos, length);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration)
            {
                currentPos = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }
}

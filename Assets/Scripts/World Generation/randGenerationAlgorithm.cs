using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class randGenerationAlgorithm
{
    public static HashSet<Vector2Int> randomWalk(Vector2Int startPos, int length)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPos);
        var prevPos = startPos;

        for (int i = 0; i < length; i++)
        {
            var newPos = prevPos + getrandDir();
            path.Add(newPos);
            prevPos = newPos;
        }
        return path;
    }

    public static List<Vector2Int> dirList = new List<Vector2Int>
    {
        new Vector2Int(0, 1), //up
        new Vector2Int(1, 0), //right
        new Vector2Int(0, -1), //down
        new Vector2Int(-1, 0) //left
    };

    public static Vector2Int getrandDir()
    {
        return dirList[Random.Range(0, dirList.Count)];
    }
}

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static utility class containing a list of directions stored as Vector2Int and functionality to generate a random direction. 
/// </summary>
public static class Direction2D
{
    /// <summary>
    /// List of cardinal directions stored in Vector2Int values.
    /// </summary>
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0,1),  // UP
        new Vector2Int(1,0),  // RIGHT
        new Vector2Int(0,-1), // DOWN
        new Vector2Int(-1,0)  // LEFT
    };

    /// <summary>
    /// Method to return a random direction from the cardinalDirectionsList.
    /// </summary>
    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)]; 
    }
}

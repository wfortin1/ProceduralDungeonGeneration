using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class containing procedural generation algorithms for simple random walk. 
/// </summary>
public static class ProceduralGenerationAlgorithms
{

    /// <summary>
    /// Performs the simple random walk algorithm to return a Hashet<Vector2Int> containing the path taken for that iteration.
    /// </summary>
   public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
   {
       HashSet<Vector2Int> path = new HashSet<Vector2Int>(); 

       path.Add(startPosition); 
       Vector2Int previousPosition = startPosition; 

       for (int i = 0; i < walkLength; i++)
       {
           Vector2Int newPosition = previousPosition + Direction2D.GetRandomCardinalDirection(); 
           path.Add(newPosition); 
           previousPosition = newPosition; 
       }
       return path; 
   }

    /// <summary>
    /// Performs the random walk algorithm to generate a single corridor and returns a HashSet<Vector2Int> containing the corridor of this iteration. 
    /// </summary>
   public static List<Vector2Int> RandomWalkCorrdior(Vector2Int startPosition, int corridorLength)
   {
        List<Vector2Int> corridor = new List<Vector2Int>(); 
        Vector2Int direction = Direction2D.GetRandomCardinalDirection(); 

        Vector2Int currentPosition = startPosition; 
        corridor.Add(currentPosition); 

        for (int i = 0; i < corridorLength; i++)
        {
            currentPosition += direction; 
            corridor.Add(currentPosition);
        }
        return corridor; 
   }
}
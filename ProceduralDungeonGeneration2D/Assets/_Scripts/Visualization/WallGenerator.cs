using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class to generate walls to be visually represented in the tilemapVisualizer class. 
/// </summary>
public static class WallGenerator
{
    /// <summary>
    /// Method to generate walls with a Hashset containing the dungeons floor positions. 
    /// </summary> 
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        HashSet<Vector2Int> basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList); 
        foreach (Vector2Int position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position); 
        }
    }

    /// <summary>
    /// Returns a HashSet containing all the wall positions using a HashSet of the floor positions. 
    /// </summary>
    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (Vector2Int position in floorPositions)
        {
            foreach (Vector2Int direction in directionList)
            {
                Vector2Int neighbourPosition = position + direction; 
                if(floorPositions.Contains(neighbourPosition) == false)
                {
                    wallPositions.Add(neighbourPosition); 
                }
            }
        }
        return wallPositions; 
    }
}

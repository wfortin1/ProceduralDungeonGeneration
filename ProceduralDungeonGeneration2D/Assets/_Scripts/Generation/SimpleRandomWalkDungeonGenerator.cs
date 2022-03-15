using System.Collections.Generic;
using System.Linq; 
using UnityEngine;
using Random = UnityEngine.Random; 

/// <summary>
/// Class for implementing simple random walk dungeon generation inheriting from AbstractDungoenGenerator. 
/// </summary>
public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkData randomWalkParameters; 

    /// <summary>
    /// Overriden method from parent class generates a HashSet of floor positions.
    /// Visually represents dungeon floor and walls. 
    /// </summary>
    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
        tilemapVisualizer.Clear(); 
        tilemapVisualizer.PaintFloorTiles(floorPositions); 
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer); 
    }

    /// <summary>
    /// Runs the random walk algorithm for a given number of iterations which is defined using ScriptableObjects to save parameters.
    /// </summary>
    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkData parameters, Vector2Int position)
    {
        Vector2Int currentPosition = position;  
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>(); 

        for (int i = 0; i < parameters.iterations; i++)
        {
            HashSet<Vector2Int> path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength); 
            floorPositions.UnionWith(path); 
            if(parameters.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count)); 
            }
        }
        return floorPositions; 
    }
}

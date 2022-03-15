using System; 
using System.Linq; 
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is to be attached to a GameObject and performs a corridor first dungeon generation implemented with the simple random walk algorithm. 
/// Inherits from the SimpleRandomWalkDungeonGenerator and the AbstractDungeonGenerator. 
/// </summary>
public class CorridorFirstDungeonGeneration : SimpleRandomWalkDungeonGenerator
{
    // Instance Variables 
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5; 

    [SerializeField]
    [Range(0.1f, 1)]
    private float roomPercent = 0.8f; 
    
    /// <summary>
    /// Override to ensure corridor first generation is being used. 
    /// </summary>
    protected override void RunProceduralGeneration()
    {
        CorridorFirstGeneration(); 
    }

    /// <summary>
    /// Generates data about corridors, rooms and sends it to the tilemapVisualizer. 
    /// </summary>
    private void CorridorFirstGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions, potentialRoomPositions); 

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions);

        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions); 

        CreateRoomsAtDeadEnds(deadEnds, roomPositions); 

        floorPositions.UnionWith(roomPositions); 

        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer); 
    }

    /// <summary>
    /// Runs iterations of the RandomWalkCorridor method and add those to the floorPositions HashSet. 
    /// </summary> 
    private void CreateCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> potentialRoomPositions)
    {
        Vector2Int currentPosition = startPosition; 
        potentialRoomPositions.Add(currentPosition); 

        for (int i = 0; i < corridorCount; i++)
        {
            List<Vector2Int> corridor = ProceduralGenerationAlgorithms.RandomWalkCorrdior(currentPosition, corridorLength); 
            currentPosition = corridor[corridor.Count - 1]; 
            potentialRoomPositions.Add(currentPosition); 
            floorPositions.UnionWith(corridor); 
        }
    }

    // GUID unity docs
    /// <summary>
    /// Creates a random ammount of rooms in random positions based on the roomPercent parameter.
    /// Returns a HashSet of room positions after creation. 
    /// </summary>
    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions)
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>(); 
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent); 

        List<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList(); 

        foreach (Vector2Int roomPosition in roomsToCreate)
        {
            HashSet<Vector2Int> roomFloor = RunRandomWalk(randomWalkParameters, roomPosition);
            roomPositions.UnionWith(roomFloor); 
        }
        return roomPositions; 
    }

    /// <summary>
    /// Method to create rooms from the specificed list of deadEnds and add it to the HashSet of roomPositions
    /// </summary>
    private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomPositions)
    {
        foreach (Vector2Int position in deadEnds)
        {
            if (roomPositions.Contains(position) == false)
            {
                HashSet<Vector2Int> room = RunRandomWalk(randomWalkParameters, position); 
                roomPositions.UnionWith(room);
            }
        }
    }

    /// <summary>
    /// Method to deal with dead ends in corridors by returning a list of dead end positions. 
    /// </summary>
    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>(); 

        foreach (Vector2Int position in floorPositions)
        {
            int neighboursCount = 0; 
            foreach (Vector2Int direction in Direction2D.cardinalDirectionsList)
            {
                if(floorPositions.Contains(position + direction))
                {
                    neighboursCount++; 
                }
            }
            if(neighboursCount == 1)
            {
                deadEnds.Add(position); 
            }
        }
        return deadEnds; 
    }
}

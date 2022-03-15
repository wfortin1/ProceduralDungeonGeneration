using UnityEngine;

/// <summary>
/// Abstract class to be implemented by all dungeon generators.
/// </summary>
public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    // TilemapVisualizer to be used for dungeon visualization
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null; 
    [SerializeField]
    // A starting position for procedural generation algorithms. 
    protected Vector2Int startPosition = Vector2Int.zero; 

    /// <summary>
    /// Called by the unity editor script to generate a dungeon.
    /// Clears previous tilemap data and starts a new procedural generation. 
    /// </summary>
    public void GenerateDungeon()
    {
        tilemapVisualizer.Clear(); 
        RunProceduralGeneration(); 
    }

    /// <summary>
    /// Abstract method to be implemented by child classes to determine how procedural generation is done. 
    /// </summary>
    protected abstract void RunProceduralGeneration(); 
}

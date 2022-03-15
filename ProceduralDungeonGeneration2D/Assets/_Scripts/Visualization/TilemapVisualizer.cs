using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

/// <summary>
/// Class to visually represent the generated dungeon with tilemaps.
/// </summary>
public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap; 

    [SerializeField]
    private Tilemap wallTilemap; 

    [SerializeField]
    private TileBase floorTile; 

    [SerializeField]
    private TileBase wallTop; 

    /// <summary>
    /// Paints all the floor tiles from a collection of Vector2Int positions.
    /// </summary>
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, floorTilemap, floorTile); 
    }

    /// <summary>
    /// Iterates through each position and sets the tile on the given tilemap to the given tile.
    /// </summary>
    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (Vector2Int position in positions)
        {
            PaintSingleTile(tilemap, tile, position); 
        }
    }
    
    /// <summary>
    /// Sets a singular tile at a specified position.
    /// </summary>
    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        Vector3Int tilePosition = tilemap.WorldToCell((Vector3Int)position); 
        tilemap.SetTile(tilePosition, tile);
    }

    /// <summary>
    /// Sets a wall tile.
    /// </summary>
    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, wallTop, position); 
    }

    /// <summary>
    /// Clears all floor and wall tiles. 
    /// </summary>
    public void Clear()
    {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();  
    }
}

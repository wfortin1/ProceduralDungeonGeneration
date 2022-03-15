using UnityEngine;

[CreateAssetMenu(fileName = "SimpleRandomWalkParameters_", menuName = "PCG/SimpleRandomWalkData")]
/// <summary>
/// Custom scriptable object class to allow for a way to save simple random walk data.
/// Easily used to generate different types of dungeons. 
/// </summary>
public class SimpleRandomWalkData : ScriptableObject
{
    // Parameters for scriptable object
    public int iterations = 10; 
    public int walkLength = 10; 
    public bool startRandomlyEachIteration = true; 
}

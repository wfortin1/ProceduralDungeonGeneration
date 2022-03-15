using System.Collections;
using System.Collections.Generic;
using UnityEditor; 
using UnityEngine;

[CustomEditor(typeof(AbstractDungeonGenerator), true)]
/// <summary>
/// Editor class to implement a new custom editor button for generating dungeons without running project.
/// </summary>
public class RandomDungeonGeneratorEditor : Editor
{
    AbstractDungeonGenerator generator; 

    // Initializes the generator
    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;     
    }

    // Creates a new GUI button that calls the GenerateDungeon method from AbstractDungeonGenerator.
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); 
        if(GUILayout.Button("Create Dungeon"))
        {
            generator.GenerateDungeon(); 
        }
    }
}

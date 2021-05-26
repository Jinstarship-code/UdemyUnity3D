using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    private void Awake() 
    {
       CreateGrid();   
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))              
            return grid[coordinates];
    
        return null;
    }

    void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y<gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x,y);
                grid.Add(coordinates, new Node(coordinates, true));
                Debug.Log(grid[coordinates].coordinates+" = "+grid[coordinates].isWalkable);
            }
        }
    }
}



/*
    ** Dictionaries
    - Stores a key-value pair
    - Keys link to values
    - The keys must be unique, and are usually very simple
    - The values can be more complex types
    - Values can be null
    - Keys can't be null
    - The lookup is very fast from key to value
    - The lookup is much slower from value to key

    <key, value>
*/
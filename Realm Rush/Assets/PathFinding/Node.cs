using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates = new Vector2Int();
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int _coordinates, bool _isWalkable)
    {
        coordinates=_coordinates;
        isWalkable=_isWalkable;
    }
}

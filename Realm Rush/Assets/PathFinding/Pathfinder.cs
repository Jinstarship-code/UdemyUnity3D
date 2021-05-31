using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    public Vector2Int GetStartCoordinates { get{return startCoordinates;}}

    [SerializeField] Vector2Int destinationCoordinates;
    public Vector2Int GetDestinationCoordinates { get{return destinationCoordinates;}}

[SerializeField]
    Node startNode;
    [SerializeField]
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = {Vector2Int.right,Vector2Int.left,Vector2Int.up,Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid=new Dictionary<Vector2Int, Node>();

    void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();

        if(gridManager !=null)
        { 
            grid= gridManager.GetGrid;
            startNode = grid[startCoordinates];
            destinationNode = grid[destinationCoordinates];
        }
        else
        {
            Debug.Log("GridManager is Null");
        }
    }

    void Start()
    {
        GetNewPath();
    }

    public List<Node> GetNewPath()
    {
        return GetNewPath(startCoordinates);
    }

    public List<Node> GetNewPath(Vector2Int coordinates)
    {
        gridManager.ResetNodes();
        BreadthFirstSearch(coordinates);

        return BuildPath();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors =  new List<Node>();

        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if(grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);
            }
        }

        foreach(Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates)&& neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }

    void BreadthFirstSearch(Vector2Int coordinates)
    {
        startNode.isWalkable = true;
        destinationNode.isWalkable = true;

        frontier.Clear();
        reached.Clear();

        bool isRunning = true;

        frontier.Enqueue(grid[coordinates]);
        reached.Add(coordinates, grid[coordinates]);

        while(frontier.Count >0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored=true;
            ExploreNeighbors();

            if(currentSearchNode.coordinates == destinationCoordinates)
            {
                isRunning =false;
            }
        }
    }

    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;

        path.Add(currentNode);
        currentNode.isPath = true;

        while(currentNode !=null)
        {
            currentNode = currentNode.connectedTo;
            
            if(currentNode !=null)
            {
                currentNode.isPath = true;
                path.Add(currentNode);
            }
        }

        path.Reverse();

        return path;
    }

    public bool WillBlockPath(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            //isWalkable = true를 담아두기 위함.
            bool previousState = grid[coordinates].isWalkable;

            grid[coordinates].isWalkable = false;
            List<Node> newPath = GetNewPath();
            grid[coordinates].isWalkable = previousState;


            if(newPath.Count <= 1)
            {
                GetNewPath();
                return true;
            }
        }
            return false;
    }

    public void NotifyReceivers()
    {
        BroadcastMessage("RecalculatePath",false,SendMessageOptions.DontRequireReceiver);
    }
}


/*

    Component.BroadcastMessage
    - Declaration
        public void BroadcastMessage(
            string methodName, 
            object parameter = null, 
            SendMessageOptions options = SendMessageOptions.RequireReceiver);

    - Description
        - Calls the method named methodName on every MonoBehaviour in this game object or any of its children.
        - The receiving method can choose to ignore parameter by having zero arguments. 
        if options is set to SendMessageOptions.RequireReceiver an error is printed when the message is not picked up by any component.
*/
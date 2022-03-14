using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerationAlgorithms
{
   public static HashSet<Vector2Int> SimpleRandomWalk(Vector2Int startPosition, int walkLength)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int CorridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>();
        var direction = Direction2D.GetRandomCardinalDirection();
        var currenPosition = startPosition;
        corridor.Add(currenPosition);
        
        for (int i = 0; i < CorridorLength; i++)
        {
            currenPosition += direction;
            corridor.Add(currenPosition);
        }
        return corridor;
    }

    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt spaceToSplit, int minimumWidth, int minimumHeight)
    {
        Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();
        List<BoundsInt> roomsList = new List<BoundsInt>();
        roomsQueue.Enqueue(spaceToSplit);
        while(roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();
            if(room.size.y >= minimumHeight && room.size.x >= minimumWidth)
            {
                if(Random.value < 0.5f)
                {
                    if(room.size.y >= minimumHeight * 2)
                    {
                        SplitHorizontally(minimumHeight, roomsQueue, room);
                    }
                    else if(room.size.x >= minimumWidth * 2)
                    {
                        SplitVertically(minimumWidth, roomsQueue, room);
                    }
                    else if(room.size.x >= minimumWidth && room.size.y >= minimumHeight)
                    {
                        roomsList.Add(room);
                    }
                }
                else
                {
                  
                    if (room.size.x >= minimumWidth * 2)
                    {
                        SplitVertically(minimumWidth, roomsQueue, room);
                    }
                    else if (room.size.y >= minimumHeight * 2)
                    {
                        SplitHorizontally(minimumHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minimumWidth && room.size.y >= minimumHeight)
                    {
                        roomsList.Add(room);
                    }

                }
            }
        }
        return roomsList;
    }

    private static void SplitVertically(int minimumWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.size.y, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z),
            new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }

    private static void SplitHorizontally(int minimumHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),
            new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));
        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }
}

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0,1),//Up
        new Vector2Int(1,0), //Right
        new Vector2Int(0,-1), //Down
        new Vector2Int(-1,0) //Left
    };
    public static List<Vector2Int> diagonalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(1,1),//Up-Right
        new Vector2Int(1,-1), //Right-Down
        new Vector2Int(-1,-1), //Down-Left
        new Vector2Int(-1,1) //Left-Up
    };

    public static List<Vector2Int> eightDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0,1),//Up
        new Vector2Int(1,1),//Up-Right
        new Vector2Int(1,0), //Right
        new Vector2Int(1,-1), //Right-Down
        new Vector2Int(0,-1), //Down
        new Vector2Int(-1,-1), //Down-Left
        new Vector2Int(-1,0), //Left
        new Vector2Int(-1,1) //Left-Up
    };


    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
}

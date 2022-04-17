using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileNavigation : MonoBehaviour
{
    [SerializeField] private Grid mapGrid;
    [SerializeField] private Transform rootTile;
    private Vector3Int tileOffset;
    
    public static TileNavigation instance;
    public Tile[,] grid;
    private Dictionary<TileBase, TerrainData> dataFromTiles;
    // Start is called before the first frame update
    
    private void Awake()
    {
        grid = new Tile[10000,10000];
        if(instance != null) Destroy(gameObject);
        instance = this;
        tileOffset = mapGrid.WorldToCell(rootTile.position);
        tileOffset.x = Mathf.Abs(tileOffset.x);
        tileOffset.y = Mathf.Abs(tileOffset.y);
    }

    public void SetTerainData(Vector3 position, Tile terrainData)
    {
        Vector3Int cellPosition = mapGrid.WorldToCell(position) + tileOffset;
        try
        {
            
            grid[cellPosition.x, cellPosition.y] = terrainData;
        }
        catch (Exception e)
        {
            Debug.LogError(terrainData.transform.position);
        }
      
    }

    public Tile GetTerainData(Vector3 position)
    {
        Debug.Log(mapGrid.WorldToCell(position));
        Vector3Int cellPosition = mapGrid.WorldToCell(position) + tileOffset;
        return grid[cellPosition.x, cellPosition.y];
    }

    public Tile GetTerainDataFromGrid(Vector3Int position)
    {
        Vector3Int gridSpace = position + tileOffset;
        return grid[gridSpace.x, gridSpace.y];
    }
    public List<Tile> GetNeighbors(Vector3Int position)
    {
        List<Tile> reti = new List<Tile>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector3Int offset = new Vector3Int(x, y, 0);
                reti.Add(GetTerainDataFromGrid(position + offset));
            }
        }

        return reti;
    }

    private List<Vector3Int> GetOffsetNeigbors(Vector3Int coordinates)
    {
        List<Vector3Int> reti = new List<Vector3Int>();
        //if row is even the offset needs to be handled differently
        if (coordinates.y % 2 == 0)
        {
            reti.Add(coordinates + new Vector3Int(-1, 1,0 ));
            reti.Add(coordinates + new Vector3Int(0, 1,0));
            reti.Add(coordinates + new Vector3Int(-1, 0,0 ));
            reti.Add(coordinates + new Vector3Int(1, 0,0 ));
            reti.Add(coordinates + new Vector3Int(-1, -1,0));
            reti.Add(coordinates + new Vector3Int(0, -1,0 ));
        }
        else
        {
            reti.Add(coordinates + new Vector3Int(0, 1,0 ));
            reti.Add(coordinates + new Vector3Int(1, 1,0 ));
            reti.Add(coordinates + new Vector3Int(-1, 0,0 ));
            reti.Add(coordinates + new Vector3Int(1, 0,0 ));
            reti.Add(coordinates + new Vector3Int(0, -1,0 ));
            reti.Add(coordinates + new Vector3Int(1, -1,0 ));
           
        }

        return reti;
    }
    public List<Vector3> GetRouteTo(Vector3 fromPosition, Vector3 toPosition)
    {
      
        Queue<Vector3Int> frontierPositions = new Queue<Vector3Int>();
        Dictionary<Vector3Int, Vector3Int> came_from = new Dictionary<Vector3Int, Vector3Int>();
        Vector3Int cellPosition = mapGrid.WorldToCell(fromPosition);
        Vector3Int target = mapGrid.WorldToCell(toPosition);
        target.z = 0;
        //frontierPositions.Add(cellPosition);
        frontierPositions.Enqueue(cellPosition);
        while (frontierPositions.Count > 0)
       //for(int i = 0; i < 8; i ++)
        {
            //= frontierPositions.Last();
            Vector3Int current = frontierPositions.Dequeue();
            if (current == target) break;
            foreach (Vector3Int neighbor in GetOffsetNeigbors(current))
            {
                if (!came_from.ContainsKey(neighbor))
                {
                    frontierPositions.Enqueue(neighbor);
                    came_from[neighbor] = current;
                }
              
            }
        
        }

        List<Vector3> reti = new List<Vector3>();
        Debug.Log("found target");
        Vector3Int test = target;
        //reti.Add(GetTerainDataFromGrid(target));
        while (test != cellPosition)
        {
            reti.Add(GetTerainDataFromGrid(test).transform.position);
            test = came_from[test];
           
            
        }


        reti.Reverse();
        return reti;
    }
    
}

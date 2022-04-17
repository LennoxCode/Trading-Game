using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileNavigation : MonoBehaviour
{
    [SerializeField] private Grid mapGrid;
    [SerializeField] private List<TerrainData> _terrainDatas;
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Transform rootTile;
    private Vector3Int tileOffset;
    private List<Vector3> frontierPositions;
    private List<Vector3> reachedPositions;
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
        Debug.Log(tileOffset);
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
        Vector3Int cellPosition = mapGrid.WorldToCell(position) + tileOffset;
        return grid[cellPosition.x, cellPosition.y];
    }
    private void Start()
    {
        TileBase test = _tilemap.GetTile(new Vector3Int(0, 0, 0));
        
    }

    public void GetRouteTo(Vector3 fromPosition, Vector3 toPosition)
    {
        
        Vector3 cellPosition = mapGrid.WorldToCell(fromPosition);
        Vector3 target = mapGrid.WorldToCell(toPosition);
        frontierPositions.Add(cellPosition);
        reachedPositions.Add(cellPosition);
        while (frontierPositions.Count > 0)
        {
            Vector3 current = frontierPositions[0];
            frontierPositions.Remove(current);
            if (current == target) break;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    Vector3 offset = new Vector3(x, y, 0);
                    frontierPositions.Add(mapGrid.WorldToCell(current + offset));
                    reachedPositions.Add(mapGrid.WorldToCell(current + offset));

                }
            }
        }
        
    }
    
}

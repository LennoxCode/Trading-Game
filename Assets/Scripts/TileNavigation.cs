using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNavigation : MonoBehaviour
{
    [SerializeField] private Grid mapGrid;
    private List<Vector3> frontierPositions;
    private List<Vector3> reachedPositions;
    public static TileNavigation instance;
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance != null) Destroy(gameObject);
        instance = this;
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

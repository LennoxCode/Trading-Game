using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileNavigation : MonoBehaviour
{
    [SerializeField] private Grid mapGrid;
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
        Debug.Log(cellPosition);
    }
}

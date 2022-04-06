using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TerrainData", menuName ="Terrain Data")]
public class Terrain : ScriptableObject
{
    public bool isAccesible;
    public float movementCost;
    public string terrainKind;
}

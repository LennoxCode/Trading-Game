using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerrainData", menuName = "Terrain Data")]
public class TradingGood : ScriptableObject
{
    public int baseCost;
    public float weight;
    public bool isEdible;
    public int foodValue;
}

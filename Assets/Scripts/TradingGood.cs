using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TradeGood", menuName = "Trade Good")]
public class TradingGood : ScriptableObject
{
    public string name;
    public int baseCost;
    public float weight;
    public bool isEdible;
    public int foodValue;
}

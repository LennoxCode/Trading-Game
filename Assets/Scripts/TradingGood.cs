using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "TradeGood", menuName = "Trade Good")]
public class TradingGood : ScriptableObject
{
    public string goodName;
    public int baseCost;
    public float weight;
    public bool isEdible;
    public int foodValue;
    public Texture2D associatedImage;
}

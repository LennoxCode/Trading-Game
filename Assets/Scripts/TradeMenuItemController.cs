using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeMenuItemController : MonoBehaviour
{
    private String tradeGoodName;
    // Start is called before the first frame update
    [SerializeField] private RawImage productIcon;
    [SerializeField] private TextMeshProUGUI productNameDisplay;
    [SerializeField] private TextMeshProUGUI productStockDisplay;

    public void UpdateTradeGoodDisplay(string goodName, int amountAvailable, Texture2D goodIcon)
    {
        productIcon.texture = goodIcon;
        productNameDisplay.text = goodName;
        productStockDisplay.text = amountAvailable + " Available";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

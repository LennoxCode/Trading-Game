using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeMenuItemController : MonoBehaviour
{
    private String tradeGoodName;

    private CityController playerCity;
    
    // Start is called before the first frame update
    [SerializeField] private RawImage productIcon;
    [SerializeField] private TextMeshProUGUI productNameDisplay;
    [SerializeField] private TextMeshProUGUI productStockDisplay;

    public void UpdateTradeGoodDisplay(string goodName, int amountAvailable, Texture2D goodIcon)
    {
        tradeGoodName = goodName;
        productIcon.texture = goodIcon;
        productNameDisplay.text = goodName;
        productStockDisplay.text = amountAvailable + " Available";
    }

    public void OnSellPressed()
    {
        playerCity.BuyGoodFromPlayer(tradeGoodName);
    }

    public void OnBuyPressed()
    {
        //playerCity.SellGoodToPlayer(tradeGoodName);
        GameEvents.current.BuyGood(tradeGoodName);
    }

    private void Awake()
    {
        GameEvents.current.updateGoodInterface += UpdateTradeGoodDisplay;
        foreach(GameObject city in GameObject.FindGameObjectsWithTag("Cities"))
        {
            if (city.GetComponent<CityController>().IsPlayerInCity()) playerCity = city.GetComponent<CityController>();
        }
    }

    public String GetGoodName()
    {
        return tradeGoodName;
    }

    public void UpdateTradeGoodDisplay(int amountAvailable)
    {
        productStockDisplay.text = amountAvailable + " Available";
    }

    private void UpdateTradeGoodDisplay(Inventory.ItemInInventory item)
    {
        if (!item.good.goodName.Equals(tradeGoodName)) return;
        TradingGood good = item.good;
        tradeGoodName = good.goodName;
        productNameDisplay.text = good.goodName;
        productStockDisplay.text = item.amountHeld + " Available";
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

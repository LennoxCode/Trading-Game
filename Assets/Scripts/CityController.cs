using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    [SerializeField]  private Inventory cityInventory;
    private static readonly float SALEMODIFIER = 0.8f;
    private bool playerIsInCity = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onTradMenuButtonWasClicked += OnTradMenuButtonWasClicked;
        GameEvents.current.buyGood += SellGoodToPlayer;
    }
    private void OnTradMenuButtonWasClicked()
    {
        if (!playerIsInCity) return;
        foreach (Inventory.ItemInInventory item in cityInventory.itemsInInventory)
        {
            MenuController.MCInstance.InstantiateTradingGood(item);
        }
    }

    public void SetupTradingMenu()
    {
        
    }

    public void SellGoodToPlayer(string goodName)
    {
        if (!playerIsInCity) return;
        int price = GetSalePriceOfGood(goodName);
        if (price == 0 || PlayerController.instance.GetMoneyAmount() - price < 0)return ;
        if (!cityInventory.SellTo(PlayerController.instance.GetInventory(), goodName, 1)) return;
        Inventory.ItemInInventory soldItem = cityInventory.GetItemByName(goodName).Value;
        GameEvents.current.UpdateGoodInterface(soldItem); 
        PlayerController.instance.ChangeMoney(-price);
    }
    public void BuyGoodFromPlayer(string goodName)
    {
        if (!playerIsInCity) return;
        int price = GetBuyPriceOfGood(goodName);
        if (price == 0) return;
        if(!cityInventory.BuyFrom(PlayerController.instance.GetInventory(), goodName, 1))return;
        Inventory.ItemInInventory soldItem = cityInventory.GetItemByName(goodName).Value;
        GameEvents.current.UpdateGoodInterface(soldItem);
        //MenuController.MCInstance.UpdateTradeGoodDisplay(cityInventory.GetItemByName(goodName).Value);
        PlayerController.instance.ChangeMoney(price);
        
    }

    public int GetSalePriceOfGood(string goodName)
    {
        Inventory.ItemInInventory? item =  cityInventory.GetItemByName(goodName);
        if (!item.HasValue) return 0;
        Inventory.ItemInInventory realItem = item.Value;
        float salePrice = realItem.good.baseCost * realItem.localModifier;
        return Mathf.RoundToInt(salePrice);
    }

    public int GetBuyPriceOfGood(string goodName)
    {
        return Mathf.RoundToInt(SALEMODIFIER * GetSalePriceOfGood(goodName) );
    }
    public bool IsPlayerInCity()
    {
        return playerIsInCity;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerController.PInstance.transform.position -  transform.position;
        distanceToPlayer.y = 0;
        if (distanceToPlayer.magnitude == 0)
        {
            playerIsInCity = true;
            MenuController.MCInstance.SetTradeButton(true);
        }
        if (distanceToPlayer.magnitude > 0 && playerIsInCity) {
            playerIsInCity = false;
            MenuController.MCInstance.SetTradeButton(false);
            MenuController.MCInstance.DeactiveTradeMenu();
            
        }
    }
}

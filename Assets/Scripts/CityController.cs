using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    [SerializeField]  private Inventory cityInventory;
    private static readonly float SALEMODIFIER;
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
        cityInventory.SellTo(PlayerController.instance.GetInventory(),goodName, 1);
       foreach (Inventory.ItemInInventory item in cityInventory.itemsInInventory)
       {
           if (item.good.goodName.Equals(goodName))
           {
               PlayerController.instance.TakeMoney((int)Math.Round(item.good.baseCost * item.localModifier));
               MenuController.MCInstance.UpdateTradeGoodDisplay(item);
           }
           
       }
    }
    public void BuyGoodFromPlayer(string goodName)
    {
        if (!playerIsInCity) return;
        int price = GetSalePriceOfGood(goodName);
        if (price == 0) return;
        cityInventory.BuyFrom(PlayerController.instance.GetInventory(), goodName, 1);
        foreach (Inventory.ItemInInventory item in cityInventory.itemsInInventory)
        {
            if (item.good.goodName.Equals(goodName))
            {
                PlayerController.instance.TakeMoney((int)Math.Round(item.good.baseCost * item.localModifier));
                MenuController.MCInstance.UpdateTradeGoodDisplay(item);
            }
           
        }
        PlayerController.instance.TakeMoney(-price);
        
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
        return Mathf.RoundToInt( GetSalePriceOfGood(goodName) * SALEMODIFIER);
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

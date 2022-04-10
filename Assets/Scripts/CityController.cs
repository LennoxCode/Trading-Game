using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    public float distanceToPlayerxd;

    [SerializeField]private Inventory cityInventory;
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
        cityInventory.BuyFrom(PlayerController.instance.GetInventory(), goodName, 1);
        foreach (Inventory.ItemInInventory item in cityInventory.itemsInInventory)
        {
            if (item.good.goodName.Equals(goodName))
            {
                PlayerController.instance.TakeMoney((int)Math.Round(item.good.baseCost * item.localModifier));
                MenuController.MCInstance.UpdateTradeGoodDisplay(item);
            }
           
        }
        
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
        this.distanceToPlayerxd = distanceToPlayer.magnitude;
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

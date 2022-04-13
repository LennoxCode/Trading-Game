using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action onTradMenuButtonWasClicked;
    public void TradMenuButtonWasClicked()
    {
        if (onTradMenuButtonWasClicked != null)
        {
            onTradMenuButtonWasClicked();
        }
    }
    public event Action playerEnteredCity;
    
    public void PlayerEnteredCity()
    {
        if (playerEnteredCity != null)
        {
            playerEnteredCity();
        }
    }

    public event Action<string> buyGood;

    public void BuyGood(string goodName)
    {
        if (buyGood != null)
        {
            buyGood(goodName);
        }
    }
    public event Action<string> sellGood;

    public void SellGood(string goodName)
    {
        if (sellGood != null)
        {
            sellGood(goodName);
        }
    }

    public event Action<Inventory.ItemInInventory> updateGoodInterface;

    public void UpdateGoodInterface(Inventory.ItemInInventory good)
    {
        if (updateGoodInterface != null)
        {
            updateGoodInterface(good);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Inventory 

{
    private int test;
    // Start is called before the first frame update
    public  ItemInInventory[] itemsInInventory;
    
    public Inventory(ItemInInventory[] itemsInInventory)
    {
        this.itemsInInventory = itemsInInventory;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeGoodAmount(string goodName, int amount)
    {
        int index = 0;
        foreach (ItemInInventory itemInsellInventory in itemsInInventory)
        {
            if (itemInsellInventory.good.goodName.Equals(goodName)) break;
            index++;
        }
        itemsInInventory[index].ChangeAmountHeld(amount);
    }
    public void SellTo(Inventory to, string goodName, int amount)
    {
        to.ChangeGoodAmount(goodName, amount);
        ChangeGoodAmount(goodName, -amount);
    }

    public void BuyFrom(Inventory from, string goodName, int amount)
    {
        from.ChangeGoodAmount(goodName, -amount);
        ChangeGoodAmount(goodName, amount);
    }
    private ItemInInventory? GetItemByName(string goodName)
    {
        foreach (ItemInInventory item in itemsInInventory)
        {
            if (item.good.goodName.Equals(goodName)) return item;
        }

        return null;
    }
    [Serializable]
    public struct ItemInInventory
    {
        ItemInInventory(TradingGood good, int amountHeld)
        {
            this.good = good;
            this.amountHeld = amountHeld;
            localModifier = 1.0f;
        }

        public void ChangeAmountHeld(int amount)
        {
            amountHeld += amount;
            
        }
        public TradingGood good;
        public int amountHeld;
        public float localModifier;

    }
}


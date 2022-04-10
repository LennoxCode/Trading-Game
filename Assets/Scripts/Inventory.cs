using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Inventory 

{
    private int test;
    // Start is called before the first frame update
    [SerializeField]private ItemInInventory[] itemsInInventory;

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

    public void SellTo(Inventory to, TradingGood good, int amount)
    {

    }
    [Serializable]
    public struct ItemInInventory
    {
        ItemInInventory(TradingGood good, int amountHeld)
        {
            this.good = good;
            this.amountHeld = amountHeld;
        }
        public TradingGood good;
        public int amountHeld;

    }
}


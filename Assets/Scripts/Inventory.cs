using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    private ArrayList itemsInInventory;

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
}
public class ItemInInventory
{
    TradingGood good;
    int amountHeld;

}

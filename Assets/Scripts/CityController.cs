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
        Debug.Log("selling the following good to player: " + goodName);
    }

    public void BuyGoodFromPlayer(string goodName)
    {
        
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

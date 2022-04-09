using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    private Inventory cityInventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetupTradingMenu() { }
    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerController.PInstance.transform.position -  transform.position;
        distanceToPlayer.y = 0;
        if (distanceToPlayer.magnitude == 0) MenuController.MCInstance.SetTradeButton(true);
        if (distanceToPlayer.magnitude > 0) {
            MenuController.MCInstance.SetTradeButton(false);
            MenuController.MCInstance.DeactiveTradeMenu();
            
        }
    }
}

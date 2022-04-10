using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    public float distanceToPlayerxd;

    private Inventory cityInventory;
    private bool playerIsInCity = false;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onTradMenuButtonWasClicked += OnTradMenuButtonWasClicked;
    }
    private void OnTradMenuButtonWasClicked()
    {
        Vector3 distanceToPlayer = PlayerController.PInstance.transform.position - transform.position;
        distanceToPlayer.y = 0;
        if (distanceToPlayer.magnitude == 0) Debug.Log("One city can have event");
    }
    public void SetupTradingMenu() { }
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

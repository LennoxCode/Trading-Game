using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public static MenuController MCInstance;
    [SerializeField] GameObject cityMenu;
    [SerializeField] GameObject tradeMenu;
    [SerializeField] GameObject tradeMenu2;
    [SerializeField] GameObject tradingGoodMenuItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (MCInstance == null) MCInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetTradeButton(bool active)
    {
        cityMenu.SetActive(active);
    }
    public void ToggleTradeMenu()
    {
        tradeMenu.SetActive(!tradeMenu.activeSelf);
        //tradeMenu.GetComponent<TradeMenuItemController>();
        ClearTradingGoods();
    }
    public void DeactiveTradeMenu()
    {
        tradeMenu.SetActive(false);
        
    }
    public void InstantiateTradingGood(Inventory.ItemInInventory itemInInventory)
    {
        GameObject newTradingGood = GameObject.Instantiate(tradingGoodMenuItemPrefab);
        newTradingGood.transform.SetParent(tradeMenu2.transform, false);
        newTradingGood.GetComponent<TradeMenuItemController>().UpdateTradeGoodDisplay(itemInInventory.good.goodName, itemInInventory.amountHeld, itemInInventory.good.associatedImage);
    }

    public void UpdateTradeGoodDisplay(Inventory.ItemInInventory itemInInventory)
    {
        foreach (Transform child in tradeMenu2.transform)
        {
            if (child.GetComponent<TradeMenuItemController>().GetGoodName().Equals(itemInInventory.good.goodName)) 
                child.GetComponent<TradeMenuItemController>().UpdateTradeGoodDisplay(itemInInventory.amountHeld);
        }
    }
    public void ClearTradingGoods()
    {
        foreach (Transform child in tradeMenu2.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
    }
}

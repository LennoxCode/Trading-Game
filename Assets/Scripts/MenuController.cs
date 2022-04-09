using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public static MenuController MCInstance;
    [SerializeField] GameObject tradeButton;
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
        tradeButton.SetActive(active);
    }
    public void ToggleTradeMenu()
    {
        tradeMenu.SetActive(!tradeMenu.activeSelf);
        MenuController.MCInstance.InstantiateTradingGood();
    }
    public void DeactiveTradeMenu()
    {
        tradeMenu.SetActive(false);
    }
    public void InstantiateTradingGood()
    {
        GameObject newTradingGood = GameObject.Instantiate(tradingGoodMenuItemPrefab);
        newTradingGood.transform.SetParent(tradeMenu2.transform, false);
    }
}

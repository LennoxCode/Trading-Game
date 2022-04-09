using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public static MenuController MCInstance;
    [SerializeField] GameObject tradeButton;
    [SerializeField] GameObject tradeMenu;
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
    }
    public void DeactiveTradeMenu()
    {
        tradeMenu.SetActive(false);
    }
}

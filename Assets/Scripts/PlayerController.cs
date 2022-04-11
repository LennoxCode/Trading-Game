using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject PInstance;
    public static PlayerController instance;
    [SerializeField] private int startMoney;
    [SerializeField] private int startFood;
    [SerializeField]private int money;
    [SerializeField]private int food;

    [SerializeField] private Inventory _inventory;
    // Start is called before the first frame update
    void Start()
    {
        PInstance = this.gameObject;
        instance = this;
        money = startMoney;
        food = startFood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int amount)
    {
        money += amount;
    }

    public int GetMoneyAmount()
    {
        return money;
    }
    public Inventory GetInventory()
    {
        return this._inventory;
    }
}

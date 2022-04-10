using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject PInstance;
    public static PlayerController instance;
    [SerializeField] private readonly int startMoney;
    [SerializeField] private readonly int startFood;
    private int money;
    private int food;

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

    public void TakeMoney(int amount)
    {
        money += amount;
    }
    public Inventory GetInventory()
    {
        return this._inventory;
    }
}

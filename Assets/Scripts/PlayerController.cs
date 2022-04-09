using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject PInstance;
    [SerializeField] private readonly int startMoney;
    [SerializeField] private readonly int startFood;
    private int money;
    private int food;
    // Start is called before the first frame update
    void Start()
    {
        PInstance = this.gameObject;
        money = startMoney;
        food = startFood;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

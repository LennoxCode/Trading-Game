using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static GameObject PInstance;
    public static PlayerController instance;
    private bool isMoving;
    [SerializeField] private  GameObject startTile;
    [SerializeField] private float movementSpeed;
    [SerializeField] private int startMoney;
    [SerializeField] private int startFood;
    [SerializeField]private int money;
    [SerializeField]private int food;

    [SerializeField] private Inventory _inventory;

    public Tile currTile;
    // Start is called before the first frame update
    void Start()
    {
        currTile = startTile.GetComponent<Tile>();
        PInstance = this.gameObject;
        instance = this;
        money = startMoney;
        food = startFood;
    }

    public IEnumerator WalkPath(List<Vector3> targets)
    {
        isMoving = true;
        foreach (Vector3 target in targets)
        {
            //transform.position = target +  new Vector3(0, 0.8f, 0);
            yield return StartCoroutine(WalkTo(target +  new Vector3(0, 0.8f, 0)));
            yield return new WaitForFixedUpdate();
        }

        isMoving = false;
    }

    public IEnumerator WalkTo(Vector3 position)
    {
        while ((transform.position - position).magnitude > 0.04)
        {
            Vector3 direction = (position - transform.position).normalized;
            transform.position += direction * Time.deltaTime * movementSpeed;
            yield return new WaitForFixedUpdate();
        }

        transform.position = position;
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

    public bool IsMoving()
    {
        return isMoving;
    }
}

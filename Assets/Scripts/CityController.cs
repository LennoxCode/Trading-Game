using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToPlayer = PlayerController.PInstance.transform.position -  transform.position;
        distanceToPlayer.y = 0;
        if (distanceToPlayer.magnitude == 0) Debug.LogError("Player is arrived at city");
    }
}

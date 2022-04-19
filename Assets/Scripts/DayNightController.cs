using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    [SerializeField] private GameObject sunRig;

    public static DayNightController instance; 
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSun(TimeController.DayTime currTime)
    {
        float rotationAngle = Mathf.LerpAngle(0, 360, currTime.hours / 12);
        sunRig.transform.eulerAngles = new Vector3(0, rotationAngle, 0);
    }
}

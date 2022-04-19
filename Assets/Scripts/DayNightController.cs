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

    public void SetSun(int passedSeconds)
    {
        float t = passedSeconds / 1440.0f;
        float rotationAngle = Mathf.Lerp(0, 360, t);
        sunRig.transform.eulerAngles = new Vector3(0, rotationAngle, 0);
    }
}

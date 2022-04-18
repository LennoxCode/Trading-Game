using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopBarController : MonoBehaviour
{
    public static TopBarController instance;

    [SerializeField] private TextMeshProUGUI foodDisplay;
    [SerializeField] private TextMeshProUGUI moneyDisplay;
    [SerializeField] private TextMeshProUGUI timeDisplay;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    public void UpdateTimeDisplay(TimeController.DayTime currTime)
    {
        timeDisplay.text = currTime.hours.ToString("00") + ":" + currTime.minutes.ToString("00");
    }

    public void UpdateRessourceDisplay(int currFood, int currMoney)
    {
        foodDisplay.text = currFood + " Food";
        moneyDisplay.text = currMoney + " Money";
    }
}

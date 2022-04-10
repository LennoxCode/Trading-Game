using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    public event Action onTradMenuButtonWasClicked;
    public void TradMenuButtonWasClicked()
    {
        if (onTradMenuButtonWasClicked != null)
        {
            onTradMenuButtonWasClicked();
        }
    }
    public event Action playerEnteredCity;

    public void PlayerEnteredCity()
    {
        if (playerEnteredCity != null)
        {
            playerEnteredCity();
        }
    }

}

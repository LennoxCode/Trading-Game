using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    private DayTime currentTime;

    public int secondsPassed;
    // Start is called before the first frame update
    void Start()
    {
        secondsPassed = 0;
        StartCoroutine(IncrementTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsPassed > 1440) EndDay();
        currentTime.hours = ((secondsPassed / 60) % 12) + 12;
        currentTime.minutes = secondsPassed % 60;
        DayNightController.instance.SetSun(secondsPassed);
    }

    private void LateUpdate()
    {
        TopBarController.instance.UpdateTimeDisplay(currentTime);
    }

    public IEnumerator IncrementTime()
    {
        while (true)
        {
            secondsPassed += 1;
            yield return new WaitForSeconds(1.0f);
        }
    }

    private void EndDay()
    {
        secondsPassed = 0;
        GameEvents.current.OnDayEnd();
        
    }
    public DayTime GetCurrentTime()
    {
        return currentTime;
    }
    public struct DayTime
    {
        public int hours;
        public int minutes;
    }
}

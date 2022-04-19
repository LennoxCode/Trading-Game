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
        currentTime.hours = ((secondsPassed / 60) % 12) + 12;
        currentTime.minutes = secondsPassed % 60;
        DayNightController.instance.SetSun(currentTime);
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
